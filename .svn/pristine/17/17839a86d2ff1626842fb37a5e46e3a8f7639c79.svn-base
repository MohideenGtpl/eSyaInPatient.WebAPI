using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaInPatient.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaInPatient.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonDataController : ControllerBase
    {
        private readonly ICommonDataRepository _commonDataRepository;
        public CommonDataController(ICommonDataRepository commonDataRepository)
        {
            _commonDataRepository = commonDataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codeType)
        {
            var ds = await _commonDataRepository.GetApplicationCodesByCodeType(codeType);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> GetApplicationCodesByCodeTypeList(List<int> l_codeType)
        {
            var ds = await _commonDataRepository.GetApplicationCodesByCodeTypeList(l_codeType);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessKey()
        {
            var ds = await _commonDataRepository.GetBusinessKey();
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreList(int businessKey)
        {
            var ds = await _commonDataRepository.GetStoreList(businessKey);
            return Ok(ds);
        }
    }
}
