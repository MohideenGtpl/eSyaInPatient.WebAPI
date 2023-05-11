﻿using eSyaInPatient.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaInPatient.IF
{
    public interface IWardServicesRepository
    {
        Task<DO_ReturnParameter> InsertIntoWardMaster(DO_WardMaster obj);

        Task<DO_ReturnParameter> UpdateWardMaster(DO_WardMaster obj);

        Task<List<DO_WardMaster>> GetWardMasterList();

        Task<List<DO_WardMaster>> GetActiveWardMasterList();

        Task<DO_WardMaster> GetWardMasterById(int wardId);

        Task<DO_ReturnParameter> InsertIntoRoomMaster(DO_RoomMaster obj);

        Task<DO_ReturnParameter> UpdateRoomMaster(DO_RoomMaster obj);

        Task<List<DO_RoomMaster>> GetRoomMasterList();

        Task<List<DO_RoomMaster>> GetActiveRoomMasterList();

        Task<DO_RoomMaster> GetRoomMasterById(int roomId);

        Task<DO_ReturnParameter> InsertIntoWardRoomBusinessLink(DO_WardRoomBusinessLink obj);

        Task<DO_ReturnParameter> UpdateWardRoomBusinessLink(DO_WardRoomBusinessLink obj);

        Task<DO_WardRoomBusinessLink> GetWardRoomBusinessByBkWrRmId(int businessKey, int wardId, int roomId);

        Task<List<DO_WardRoomBusinessLink>> GetWardListByBusinessId(int businessKey);

        Task<List<DO_WardRoomBusinessLink>> GetRoomListByBkWardId(int businessKey, int wardId);

        Task<DO_ReturnParameter> InsertIntoBedMaster(DO_BedMaster obj);

        Task<DO_ReturnParameter> UpdateBedMaster(DO_BedMaster obj);

        Task<List<DO_BedMaster>> GetBedMasterByBkRmId(int businessKey, int roomId, int codeTypeLocation);

        Task<DO_ReturnParameter> InsertIntoWardRateLink(DO_WardRateLink obj);

        Task<DO_ReturnParameter> UpdateWardRateLink(DO_WardRateLink obj);

        Task<DO_ReturnParameter> InsertOrUpdateWardRateLink(List<DO_WardRateLink> obj);

        Task<List<DO_WardRateLink>> GetWardEffectiveRateByBkRateType(int businessKey, int rateType);

        Task<List<DO_WardRateLink>> GetWardPreviousRateByBkRateType(int businessKey, int rateType);
    }
}
