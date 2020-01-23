using System.Collections.Generic;
using System.Web.Http;
using TariffServices.Data.Interfaces;
using TariffServices.Data.Models;

namespace TariffsCalculator.Controllers
{
    public class TariffController : ApiController
    {
        private ITariffRepository tariffRepository;

        public TariffController(ITariffRepository _tariffRepository)
        {
            tariffRepository = _tariffRepository;
        }
        /// <summary>
        /// Gets the examples supplied by the test.
        /// </summary>
        /// <returns></returns>
        // GET api/Tariffs
        public IEnumerable<TariffCosts> Get()
        {
            return tariffRepository.GetAllTariffsExamples();
        }

        /// <summary>
        /// Gets the consumption value for both the basic and packaged tariff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/Tariffs/5
        public IHttpActionResult Get(int id)
        {
            return Ok(tariffRepository.GetTariffCostsByConsumption(id));
        }
      
    }
}
