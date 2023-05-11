﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eSyaInPatient.IF;
using eSyaInPatient.DO;


namespace eSyaInPatient.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WardServicesController : ControllerBase
    {
        private readonly IWardServicesRepository _WardServicesRepository;

        public WardServicesController(IWardServicesRepository wardMasterRepository)
        {
            _WardServicesRepository = wardMasterRepository;
        }

        /// <summary>
        /// Insert into Ward Master Table
        /// UI Reffered - Ward Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoWardMaster(DO_WardMaster obj)
        {
            var msg = await _WardServicesRepository.InsertIntoWardMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Ward Master Table
        /// UI Reffered - Ward Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateWardMaster(DO_WardMaster obj)
        {
            var msg = await _WardServicesRepository.UpdateWardMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Ward Master List
        /// UI Reffered - Ward Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWardMasterList()
        {
            var msg = await _WardServicesRepository.GetWardMasterList();
            return Ok(msg);
        }

        /// <summary>
        /// Get Active Ward Master List
        /// UI Reffered - Ward Room Business Link,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveWardMasterList()
        {
            var msg = await _WardServicesRepository.GetActiveWardMasterList();
            return Ok(msg);
        }


        /// <summary>
        /// Get Ward Master By Ward Id
        /// UI Reffered - Ward Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWardMasterById(int wardId)
        {
            var msg = await _WardServicesRepository.GetWardMasterById(wardId);
            return Ok(msg);
        }

        /// <summary>
        /// Insert into Room Master Table
        /// UI Reffered - Room Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoRoomMaster(DO_RoomMaster obj)
        {
            var msg = await _WardServicesRepository.InsertIntoRoomMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Room Master Table
        /// UI Reffered - Room Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateRoomMaster(DO_RoomMaster obj)
        {
            var msg = await _WardServicesRepository.UpdateRoomMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Room Master List
        /// UI Reffered - Room Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetRoomMasterList()
        {
            var msg = await _WardServicesRepository.GetRoomMasterList();
            return Ok(msg);
        }

        /// <summary>
        /// Get Active Room Master List
        /// UI Reffered - Ward Room Business Link,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetActiveRoomMasterList()
        {
            var msg = await _WardServicesRepository.GetActiveRoomMasterList();
            return Ok(msg);
        }

        /// <summary>
        /// Get Room Master By Room Id
        /// UI Reffered - Room Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetRoomMasterById(int roomId)
        {
            var msg = await _WardServicesRepository.GetRoomMasterById(roomId);
            return Ok(msg);
        }

        /// <summary>
        /// Insert into Ward Room Business Link Table
        /// UI Reffered - Ward Room Business Link,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoWardRoomBusinessLink(DO_WardRoomBusinessLink obj)
        {
            var msg = await _WardServicesRepository.InsertIntoWardRoomBusinessLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Ward Room Business Link Table
        /// UI Reffered - Ward Room Business Link,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateWardRoomBusinessLink(DO_WardRoomBusinessLink obj)
        {
            var msg = await _WardServicesRepository.UpdateWardRoomBusinessLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Ward Room Business Link By Business Key,WardId,RoomId
        /// UI Reffered - Ward Room Business Link,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWardRoomBusinessByBkWrRmId(int businessKey, int wardId, int roomId)
        {
            var msg = await _WardServicesRepository.GetWardRoomBusinessByBkWrRmId(businessKey, wardId, roomId);
            return Ok(msg);
        }

        /// <summary>
        /// Get Ward List By Business Key
        /// UI Reffered - Bed Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWardListByBusinessId(int businessKey)
        {
            var msg = await _WardServicesRepository.GetWardListByBusinessId(businessKey);
            return Ok(msg);
        }

        /// <summary>
        /// Get Room List By Business Key
        /// UI Reffered - Bed Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetRoomListByBkWardId(int businessKey, int wardId)
        {
            var msg = await _WardServicesRepository.GetRoomListByBkWardId(businessKey, wardId);
            return Ok(msg);
        }


        /// <summary>
        /// Insert into Bed Master Table
        /// UI Reffered - Bed Master,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoBedMaster(DO_BedMaster obj)
        {
            var msg = await _WardServicesRepository.InsertIntoBedMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Bed Master Table
        /// UI Reffered - Bed Master Link,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateBedMaster(DO_BedMaster obj)
        {
            var msg = await _WardServicesRepository.UpdateBedMaster(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Bed Master By Business Key,RoomId
        /// UI Reffered - Bed Master,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetBedMasterByBkRmId(int businessKey, int roomId, int codeTypeLocation)
        {
            var msg = await _WardServicesRepository.GetBedMasterByBkRmId(businessKey, roomId, codeTypeLocation);
            return Ok(msg);
        }

        /// <summary>
        /// Insert into Ward Rate Link Table
        /// UI Reffered - Ward Rate Tariff,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertIntoWardRateLink(DO_WardRateLink obj)
        {
            var msg = await _WardServicesRepository.InsertIntoWardRateLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Update Ward Rate Link Table
        /// UI Reffered - Ward Rate Tariff,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateWardRateLink(DO_WardRateLink obj)
        {
            var msg = await _WardServicesRepository.UpdateWardRateLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Insert / Update Into Ward Rate Link Table
        /// UI Reffered - Ward Rate Tariff,
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateWardRateLink(List<DO_WardRateLink> obj)
        {
            var msg = await _WardServicesRepository.InsertOrUpdateWardRateLink(obj);
            return Ok(msg);
        }

        /// <summary>
        /// Get Current Bed Rate By Business Key,RateType
        /// UI Reffered - Ward Rate Tariff,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWardEffectiveRateByBkRateType(int businessKey, int rateType)
        {
            var msg = await _WardServicesRepository.GetWardEffectiveRateByBkRateType(businessKey, rateType);
            return Ok(msg);
        }

        /// <summary>
        /// Get Previous Bed Rate By Business Key,RateType
        /// UI Reffered - Ward Rate Tariff,
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWardPreviousRateByBkRateType(int businessKey, int rateType)
        {
            var msg = await _WardServicesRepository.GetWardPreviousRateByBkRateType(businessKey, rateType);
            return Ok(msg);
        }
    }
}