using APIDapper.Repositories.Interfaces;
using BercaCafe_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BercaCafe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder orderRepository;
        private readonly IEmployeeUser employeeUserRepository;
        private readonly IMenu menuRepository;
        private readonly IComposition compositionRepository;
        private readonly ICompositionType compositionTypeRepository;
        private readonly IRefill refillRepository;
        public OrdersController(
            IOrder repository,
            IEmployeeUser empRepository,
            IMenu menuRepository,
            IComposition compositionRepository,
            ICompositionType compositionTypeRepository,
            IRefill refillRepository
            )
        {
            this.orderRepository = repository;
            this.employeeUserRepository = empRepository;
            this.menuRepository = menuRepository;
            this.compositionRepository = compositionRepository;
            this.compositionTypeRepository = compositionTypeRepository;
            this.refillRepository = refillRepository;
        }

        [HttpPost]
        public ActionResult PlaceOrder(OrderVM order)
        {
            try
            {
                var emp = employeeUserRepository.GetByCardNo(order.CardNo);
                if (emp.ErrorCode.Contains("resign"))
                {
                    return StatusCode(400, new
                    {
                        status = HttpStatusCode.BadRequest,
                        message = emp.ErrorCode
                    });
                }
                else if (emp.ErrorCode != "-")
                {
                    return StatusCode(400, new
                    {
                        status = HttpStatusCode.BadRequest,
                        message = "Maaf, Anda sudah melakukan tapping hari ini"
                    });
                }
                else
                {
                    try
                    {
                        var menu = menuRepository.GetMenuById(order.menuID);
                        order.menuID = menu.MenuID;
                        List<UpdateCompTypeVM> updateComps = new List<UpdateCompTypeVM>();
                        var menuComposition = compositionRepository.GetByMenu(order.menuID, order.typeMenu);
                        if (menuComposition.Count() != 0)
                        {
                            foreach (var comp in menuComposition)
                            {
                                UpdateCompTypeVM update = new UpdateCompTypeVM();
                                update.CompTypeID = comp.CompTypeID;
                                update.Quantity = comp.Quantity;
                                updateComps.Add(update);
                            }
                            if (order.cupID == 2)
                            {
                                UpdateCompTypeVM cupType = new UpdateCompTypeVM();
                                cupType.CompTypeID = 12;
                                cupType.Quantity = 1;
                                updateComps.Add(cupType);
                            }
                            foreach (var compType in updateComps)
                            {
                                bool compositionIsInsufficient = InsufficientCompType(compType);
                                if (compositionIsInsufficient)
                                {
                                    try
                                    {
                                        var refillMaterial = refillRepository.Get(compType.CompTypeID);
                                        refillRepository.Decr(refillMaterial.MaterialsID);
                                        refillRepository.Refill(refillMaterial.CompTypeID, refillMaterial.MaterialsQuantity);
                                    }
                                    catch (Exception ex)
                                    {
                                        return StatusCode(500, new
                                        {
                                            StatusCode = HttpStatusCode.InternalServerError,
                                            message = "Needed material stock in warehouse runs out",
                                            exceptionMessage = ex.Message
                                        });
                                    }
                                }
                                else
                                {
                                }
                            }
                            foreach (var compTypeCompareFinal in updateComps)
                            {
                                bool compositionIsInsufficient = InsufficientCompType(compTypeCompareFinal);
                                if (compositionIsInsufficient)
                                {
                                    return StatusCode(400, new
                                    {
                                        status = HttpStatusCode.BadRequest,
                                        message = "Bahan baku tidak cukup"
                                    });
                                }
                                else
                                {
                                }
                            }
                            foreach (var compTypeSubstract in updateComps)
                            {
                                compositionTypeRepository.SubstractCompositionType(compTypeSubstract);
                            }
                        }
                        else
                        {
                        }
                        // placing order
                        var transaction = orderRepository.ComposeOrder(emp, order);
                        var result = orderRepository.PlaceOrder(transaction);
                        return StatusCode(200, new
                        {
                            status = HttpStatusCode.OK,
                            message = "Pesanan berhasil ditambahkan",
                            result = result
                        });
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(400, new
                        {
                            status = HttpStatusCode.BadRequest,
                            message = "Menu tidak ada",
                            exceptionMessage = ex.Message
                        });
                    }
                }
            }
            catch
            {
                return StatusCode(400, new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Kartu invalid"
                });
            }
        }
        public bool InsufficientCompType(UpdateCompTypeVM compType)
        {
            var stock = compositionTypeRepository.Get(compType.CompTypeID);
            return stock.TypeQuantity < compType.Quantity;
        }
    }
}
