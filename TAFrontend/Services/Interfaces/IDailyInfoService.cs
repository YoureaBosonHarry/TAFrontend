using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAFrontend.Models;

namespace TAFrontend.Services.Interfaces
{
    public interface IDailyInfoService
    {
        Task<IEnumerable<Tickers>> GetTickersAsync();
        Task<IEnumerable<TickerDailyInfo>> GetDailyInfoByTickerAsync(string ticker);
    }
}
