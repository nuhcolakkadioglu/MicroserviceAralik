﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Results.OrderDetailResults;
public class GetOrderDetailQueryResult
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderingId { get; set; }
}