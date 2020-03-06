using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffServices.Data.Models;

namespace TariffServices.Data.Interfaces
{
    public interface ITariffRepository
    {
        List<TariffCosts> GetAllTariffsExamples();

        List<TariffCosts> GetTariffCostsByConsumption(int consumption);
    }
}
