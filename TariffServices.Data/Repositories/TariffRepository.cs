using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffServices.Data.Interfaces;
using TariffServices.Data.Models;

namespace TariffServices.Data.Repositories
{
    public class TariffRepository : ITariffRepository
    {

        private List<TariffCosts> _tariffCosts;
        
        public List<TariffCosts> TariffCostsList = new List<TariffCosts>()
        {
            new TariffCosts { TariffName = "basic electricity tariff - 3500kWh/year", AnnualCosts = 830},
            new TariffCosts { TariffName = "basic electricity tariff - 4500kWh/year", AnnualCosts = 1050},
            new TariffCosts { TariffName = "basic electricity tariff - 6000kWh/year", AnnualCosts = 1380},

            new TariffCosts { TariffName = "Packaged tariff - 3500kWh/year", AnnualCosts = 800},
            new TariffCosts { TariffName = "Packaged tariff - 4500kWh/year", AnnualCosts = 950},
            new TariffCosts { TariffName = "Packaged tariff - 6000kWh/year", AnnualCosts = 1400}
        };

        public List<TariffCosts> GetAllTariffsExamples()
        {
            return TariffCostsList;
        }

        public List<TariffCosts> GetTariffCostsByConsumption(int consumption)
        {
            _tariffCosts = new List<TariffCosts>();

            BuildBasicConsumption(consumption);

            BuildPackagedConsumption(consumption);

            return _tariffCosts.OrderBy(x => x.AnnualCosts).ToList();
        }

        private void BuildPackagedConsumption(int consumption)
        {
            double packagedCost;
            if (consumption <= 4000)
                packagedCost = 800;
            else
                packagedCost = ((consumption - 4000) * 0.30) + 800;

            var packagedTariffCost = new TariffCosts()
            {
                TariffName = "Packaged Tariff",
                AnnualCosts = packagedCost
            };

            _tariffCosts.Add(packagedTariffCost);
        }

        private void BuildBasicConsumption(int consumption)
        {
            //(5€ *12 months = 60 € base costs + 3500 kWh / year * 22 cent / kWh = 770 € consumption costs) 
            var basicCost = 60 + (consumption * 0.22);
            var basicTariffCost = new TariffCosts()
            {
                TariffName = "Basic Electric Tariff",
                AnnualCosts = basicCost
            };

            _tariffCosts.Add(basicTariffCost);
        }
    }
}
