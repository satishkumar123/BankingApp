using System;
using System.Collections.Generic;

namespace BankingApp_CICD.EF.Models;

public partial class AccountDetail
{
    public int AccId { get; set; }

    public long AccNo { get; set; }

    public string? AccName { get; set; }

    public string? AccType { get; set; }

    public int? AccBalance { get; set; }
}
