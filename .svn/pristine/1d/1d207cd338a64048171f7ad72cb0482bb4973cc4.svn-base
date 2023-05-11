using System;
using System.Collections.Generic;
using System.Text;
using eSyaInPatient.IF;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eSyaInPatient.DO;
using eSyaInPatient.DL.Entities;

namespace eSyaInPatient.DL.Repository
{
    public class WardServicesRepository : IWardServicesRepository
    {
        #region Ward Master

        public async Task<DO_ReturnParameter> InsertIntoWardMaster(DO_WardMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var isWardExist = db.GtEswrms.Where(x => x.WardDesc.ToUpper().Trim() == obj.WardDesc.ToUpper().Trim()).Count();
                        if (isWardExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Description already Exists" };
                        }

                        isWardExist = db.GtEswrms.Where(x => x.WardShortDesc.ToUpper().Trim() == obj.WardShortDesc.ToUpper().Trim()).Count();
                        if (isWardExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Short Description already Exists" };
                        }

                        int maxWardId = db.GtEswrms.Select(w => w.WardId).DefaultIfEmpty().Max();
                        int WardId = maxWardId + 1;

                        var wr_ms = new GtEswrms
                        {
                            WardId = WardId,
                            WardShortDesc = obj.WardShortDesc.Trim(),
                            WardDesc = obj.WardDesc.Trim(),
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,

                        };
                        db.GtEswrms.Add(wr_ms);

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Ward Master Created Successfully."};
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateWardMaster(DO_WardMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEswrms wr_ms = db.GtEswrms.Where(w => w.WardId == obj.WardId).FirstOrDefault();
                        if (wr_ms == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Id does not exist." };
                        }

                        var isWardExist = db.GtEswrms.Where(x => x.WardDesc.ToUpper().Trim() == obj.WardDesc.ToUpper().Trim() && x.WardId != obj.WardId).Count();
                        if (isWardExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Description already Exists" };
                        }

                        isWardExist = db.GtEswrms.Where(x => x.WardShortDesc.ToUpper().Trim() == obj.WardShortDesc.ToUpper().Trim() && x.WardId != obj.WardId).Count();
                        if (isWardExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Short Description already Exists" };
                        }

                        wr_ms.WardDesc = obj.WardDesc.Trim();
                        wr_ms.WardShortDesc = obj.WardShortDesc;
                        wr_ms.ActiveStatus = obj.ActiveStatus;
                        wr_ms.ModifiedBy = obj.UserID;
                        wr_ms.ModifiedOn = System.DateTime.Now;
                        wr_ms.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Ward Master Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_WardMaster>> GetWardMasterList()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_ms = db.GtEswrms
                        .AsNoTracking()
                        .Select(r => new DO_WardMaster
                        {
                            WardId = r.WardId,
                            WardShortDesc = r.WardShortDesc,
                            WardDesc = r.WardDesc,
                            ActiveStatus = r.ActiveStatus
                        }).OrderBy(x => x.WardDesc).ToListAsync();

                    return await wr_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_WardMaster>> GetActiveWardMasterList()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_ms = db.GtEswrms
                        .Where(w => w.ActiveStatus)
                        .AsNoTracking()
                        .Select(r => new DO_WardMaster
                        {
                            WardId = r.WardId,
                            WardShortDesc = r.WardShortDesc,
                            WardDesc = r.WardDesc
                        }).OrderBy(x => x.WardDesc).ToListAsync();

                    return await wr_ms;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_WardMaster> GetWardMasterById(int wardId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_ms = db.GtEswrms
                        .Where(w => w.WardId == wardId)
                        .AsNoTracking()
                        .Select(r => new DO_WardMaster
                        {
                            WardId = r.WardId,
                            WardShortDesc = r.WardShortDesc,
                            WardDesc = r.WardDesc,
                            ActiveStatus = r.ActiveStatus

                        }).FirstOrDefaultAsync();

                    return await wr_ms;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion Ward Master

        #region Room Master

        public async Task<DO_ReturnParameter> InsertIntoRoomMaster(DO_RoomMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var isRoomExist = db.GtEswrrm.Where(x => x.RoomDesc.ToUpper().Trim() == obj.RoomDesc.ToUpper().Trim()).Count();
                        if (isRoomExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Description already Exists" };
                        }

                        isRoomExist = db.GtEswrrm.Where(x => x.RoomShortDesc.ToUpper().Trim() == obj.RoomShortDesc.ToUpper().Trim()).Count();
                        if (isRoomExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Short Description already Exists" };
                        }

                        int maxRoomId = db.GtEswrrm.Select(w => w.RoomId).DefaultIfEmpty().Max();
                        int RoomId = maxRoomId + 1;

                        var wr_rm = new GtEswrrm
                        {
                            RoomId = RoomId,
                            Gender = obj.Gender,
                            RoomShortDesc = obj.RoomShortDesc.Trim(),
                            RoomDesc = obj.RoomDesc.Trim(),
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,
                        };
                        db.GtEswrrm.Add(wr_rm);

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Room Master Created Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateRoomMaster(DO_RoomMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEswrrm wr_rm = db.GtEswrrm.Where(w => w.RoomId == obj.RoomId).FirstOrDefault();
                        if (wr_rm == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Id does not exist." };
                        }

                        var isRoomExist = db.GtEswrrm.Where(x => x.RoomDesc.ToUpper().Trim() == obj.RoomDesc.ToUpper().Trim() && x.RoomId != obj.RoomId).Count();
                        if (isRoomExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Description already Exists" };
                        }

                        isRoomExist = db.GtEswrrm.Where(x => x.RoomShortDesc.ToUpper().Trim() == obj.RoomShortDesc.ToUpper().Trim() && x.RoomId != obj.RoomId).Count();
                        if (isRoomExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room Short Description already Exists" };
                        }

                        wr_rm.Gender = obj.Gender.Trim();
                        wr_rm.RoomShortDesc = obj.RoomShortDesc;
                        wr_rm.RoomDesc = obj.RoomDesc.Trim();
                        wr_rm.ActiveStatus = obj.ActiveStatus;
                        wr_rm.ModifiedBy = obj.UserID;
                        wr_rm.ModifiedOn = System.DateTime.Now;
                        wr_rm.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Room Master Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_RoomMaster>> GetRoomMasterList()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_rm = db.GtEswrrm
                        .AsNoTracking()
                        .Select(r => new DO_RoomMaster
                        {
                            RoomId = r.RoomId,
                            Gender = r.Gender,
                            RoomShortDesc = r.RoomShortDesc,
                            RoomDesc = r.RoomDesc,
                            ActiveStatus = r.ActiveStatus
                        }).OrderBy(x => x.RoomDesc).ToListAsync();

                    return await wr_rm;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_RoomMaster>> GetActiveRoomMasterList()
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_rm = db.GtEswrrm
                        .Where(w=> w.ActiveStatus)
                        .AsNoTracking()
                        .Select(r => new DO_RoomMaster
                        {
                            RoomId = r.RoomId,
                            Gender = r.Gender,
                            RoomShortDesc = r.RoomShortDesc,
                            RoomDesc = r.RoomDesc
                        }).OrderBy(x => x.RoomDesc).ToListAsync();

                    return await wr_rm;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<DO_RoomMaster> GetRoomMasterById(int roomId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_rm = db.GtEswrrm
                        .Where(w => w.RoomId == roomId)
                        .AsNoTracking()
                        .Select(r => new DO_RoomMaster
                        {
                            RoomId = r.RoomId,
                            Gender = r.Gender,
                            RoomShortDesc = r.RoomShortDesc,
                            RoomDesc = r.RoomDesc,
                            ActiveStatus = r.ActiveStatus
                        }).FirstOrDefaultAsync();

                    return await wr_rm;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion Room Master

        #region WardRoom Business Link

        public async Task<DO_ReturnParameter> InsertIntoWardRoomBusinessLink(DO_WardRoomBusinessLink obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var isWRLinkExist = db.GtEswrbl.Where(x => x.BusinessKey == obj.BusinessKey && x.WardId == obj.WardId && x.RoomId == obj.RoomId).Count();
                        if (isWRLinkExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Room Business Link already Exists" };
                        }

                        isWRLinkExist = db.GtEswrbl.Where(x => x.BusinessKey == obj.BusinessKey && x.WardId != obj.WardId && x.RoomId == obj.RoomId).Count();
                        if (isWRLinkExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Room already Linked with other Ward" };
                        }

                        var wr_bl = new GtEswrbl
                        {
                            BusinessKey = obj.BusinessKey,
                            WardId = obj.WardId,
                            RoomId = obj.RoomId,
                            NoOfBeds = obj.NoOfBeds,
                            OccupiedBeds = obj.OccupiedBeds,
                            ConsignmentMarkupPerc = obj.ConsignmentMarkupPerc,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,
                        };
                        db.GtEswrbl.Add(wr_bl);

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Ward Room Business Linked Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateWardRoomBusinessLink(DO_WardRoomBusinessLink obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEswrbl wr_bl = db.GtEswrbl.Where(w => w.BusinessKey == obj.BusinessKey && w.WardId == obj.WardId && w.RoomId == obj.RoomId).FirstOrDefault();
                        if (wr_bl == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Room Business Link does not exist." };
                        }

                        wr_bl.NoOfBeds = obj.NoOfBeds;
                        //wr_bl.OccupiedBeds = obj.OccupiedBeds;
                        wr_bl.ConsignmentMarkupPerc = obj.ConsignmentMarkupPerc;
                        wr_bl.ActiveStatus = obj.ActiveStatus;
                        wr_bl.ModifiedBy = obj.UserID;
                        wr_bl.ModifiedOn = System.DateTime.Now;
                        wr_bl.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Ward Room Business Link Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_WardRoomBusinessLink> GetWardRoomBusinessByBkWrRmId(int businessKey, int wardId, int roomId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_bl = db.GtEswrbl
                        .Where(w => w.BusinessKey == businessKey && w.WardId == wardId  && w.RoomId == roomId)
                        .AsNoTracking()
                        .Select(r => new DO_WardRoomBusinessLink
                        {
                            NoOfBeds = r.NoOfBeds,
                            OccupiedBeds = r.OccupiedBeds,
                            ConsignmentMarkupPerc = r.ConsignmentMarkupPerc,
                            ActiveStatus = r.ActiveStatus
                        }).FirstOrDefaultAsync();

                    return await wr_bl;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_WardRoomBusinessLink>> GetWardListByBusinessId(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_bl = db.GtEswrbl
                        .Join(db.GtEswrms,
                        b => new { b.WardId },
                        m => new { m.WardId },
                        (b,m) => new { b,m })
                        .Where(w => w.b.BusinessKey == businessKey)
                        .AsNoTracking()
                        .Select(r => new DO_WardRoomBusinessLink
                        {
                            WardId = r.b.WardId,
                            WardDesc = r.m.WardDesc
                        }).Distinct().ToListAsync();

                    return await wr_bl;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_WardRoomBusinessLink>> GetRoomListByBkWardId(int businessKey, int wardId)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_bl = db.GtEswrbl
                        .Join(db.GtEswrrm,
                        b => new { b.RoomId },
                        m => new { m.RoomId },
                        (b, m) => new { b, m })
                        .Where(w => w.b.BusinessKey == businessKey)
                        .AsNoTracking()
                        .Select(r => new DO_WardRoomBusinessLink
                        {
                            RoomId = r.b.RoomId,
                            RoomDesc = r.m.RoomDesc
                        }).Distinct().ToListAsync();

                    return await wr_bl;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion WardRoom Business Link

        #region Bed Master

        public async Task<DO_ReturnParameter> InsertIntoBedMaster(DO_BedMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var isBedMasterExist = db.GtEswrbm.Where(x => x.BusinessKey == obj.BusinessKey && x.RoomId == obj.RoomId && x.BedNumber == obj.BedNumber).Count();
                        if (isBedMasterExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Bed Number already Exists." };
                        }

                        var wr_bm = new GtEswrbm
                        {
                            BusinessKey = obj.BusinessKey,
                            RoomId = obj.RoomId,
                            BedNumber = obj.BedNumber,
                            RoomNumber = obj.RoomNumber,
                            StoreCode = obj.StoreCode,
                            LocationId = obj.LocationId,
                            HospitalNumber = obj.HospitalNumber,
                            Gender = obj.Gender,
                            BedStatus = obj.BedStatus,
                            Remarks = obj.Remarks,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,
                        };
                        db.GtEswrbm.Add(wr_bm);

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Bed Master Created Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateBedMaster(DO_BedMaster obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEswrbm wr_bm = db.GtEswrbm.Where(w => w.BusinessKey == obj.BusinessKey && w.RoomId == obj.RoomId && w.BedNumber == obj.BedNumber).FirstOrDefault();
                        if (wr_bm == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Bed Number does not exist." };
                        }

                        wr_bm.RoomNumber = obj.RoomNumber;
                        wr_bm.StoreCode = obj.StoreCode;
                        wr_bm.LocationId = obj.LocationId;
                        wr_bm.Gender = obj.Gender;
                        //wr_bm.BedStatus = obj.BedStatus;
                        wr_bm.Remarks = obj.Remarks;
                        wr_bm.ActiveStatus = obj.ActiveStatus;
                        wr_bm.ModifiedBy = obj.UserID;
                        wr_bm.ModifiedOn = System.DateTime.Now;
                        wr_bm.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Bed Master Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_BedMaster>> GetBedMasterByBkRmId(int businessKey, int roomId,int codeTypeLocation)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_bm = db.GtEswrbm
                        .GroupJoin(db.GtEcstrm,
                        b => new { b.StoreCode },
                        s => new { s.StoreCode },
                        (b, s) => new { b, s = s.FirstOrDefault() }).DefaultIfEmpty()
                        .GroupJoin(db.GtEcapcd.Where(w => w.CodeType == codeTypeLocation),
                        bs => new { bs.b.LocationId },
                        a => new { LocationId = a.ApplicationCode },
                        (bs, a) => new { bs, a = a.FirstOrDefault() }).DefaultIfEmpty()
                        .Where(w => w.bs.b.BusinessKey == businessKey && w.bs.b.RoomId == roomId)
                        .AsNoTracking()
                        .Select(r => new DO_BedMaster
                        {
                            RoomNumber = r.bs.b.RoomNumber,
                            BedNumber = r.bs.b.BedNumber,
                            StoreCode = r.bs.b.StoreCode,
                            StoreDesc = r.bs.s != null ? r.bs.s.StoreDesc : null,
                            LocationId = r.bs.b.LocationId,
                            LocationDesc = r.a != null ? r.a.CodeDesc : null,
                            HospitalNumber = r.bs.b.HospitalNumber,
                            Gender = r.bs.b.Gender,
                            BedStatus = r.bs.b.BedStatus,
                            Remarks = r.bs.b.Remarks,
                            ActiveStatus = r.bs.b.ActiveStatus
                        }).ToListAsync();

                    return await wr_bm;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion Bed Master

        #region Ward Rate Link

        public async Task<DO_ReturnParameter> InsertIntoWardRateLink(DO_WardRateLink obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var isWardRateExist = db.GtEswrrl.Where(x => x.BusinessKey == obj.BusinessKey && x.WardId == obj.WardId && x.RoomId == obj.RoomId 
                        && x.RateType == obj.RateType && x.EffectiveFrom <= obj.EffectiveFrom && (x.EffectiveTill ?? obj.EffectiveFrom) >= obj.EffectiveFrom).Count();
                        if (isWardRateExist > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Rate already Exists." };
                        }

                        var wr_rl = new GtEswrrl
                        {
                            BusinessKey = obj.BusinessKey,
                            WardId = obj.WardId,
                            RoomId = obj.RoomId,
                            RateType = obj.RateType,
                            EffectiveFrom = obj.EffectiveFrom,
                            Tariff = obj.Tariff,
                            DayCareTariff = obj.DayCareTariff,
                            EffectiveTill = obj.EffectiveTill,
                            ServiceChargePerc = obj.ServiceChargePerc,
                            ActiveStatus = obj.ActiveStatus,
                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID,
                        };
                        db.GtEswrrl.Add(wr_rl);

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Ward Rate Linked Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> UpdateWardRateLink(DO_WardRateLink obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        GtEswrrl wr_rl = db.GtEswrrl.Where(w => w.BusinessKey == obj.BusinessKey && w.WardId == obj.WardId && w.RoomId == obj.RoomId 
                        && w.RateType == obj.RateType && w.EffectiveFrom == obj.EffectiveFrom).FirstOrDefault();
                        if (wr_rl == null)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Ward Rate does not exist." };
                        }

                        wr_rl.Tariff = obj.Tariff;
                        wr_rl.DayCareTariff = obj.DayCareTariff;
                        wr_rl.EffectiveTill = obj.EffectiveTill;
                        wr_rl.ServiceChargePerc = obj.ServiceChargePerc;
                        wr_rl.ActiveStatus = obj.ActiveStatus;
                        wr_rl.ModifiedBy = obj.UserID;
                        wr_rl.ModifiedOn = System.DateTime.Now;
                        wr_rl.ModifiedTerminal = obj.TerminalID;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Ward Rate Link Updated Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<DO_ReturnParameter> InsertOrUpdateWardRateLink(List<DO_WardRateLink> obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var is_ValData = obj.Count();
                        if (is_ValData <= 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Select Data to Save." };
                        }

                        is_ValData = obj.Where(w => w.EffectiveFrom == null).Count();
                        if (is_ValData > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Select Effective From." };
                        }

                        is_ValData = obj.Where(w => w.Tariff < 0).Count();
                        if (is_ValData > 0)
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Please Enter Tariff." };
                        }

                        foreach (var bl in obj.Where(w => w.BusinessKey > 0))
                        {
                            GtEswrrl wr_rl = db.GtEswrrl.Where(w => w.BusinessKey == bl.BusinessKey && w.WardId == bl.WardId && w.RoomId == bl.RoomId
                            && w.RateType == bl.RateType && w.EffectiveFrom == bl.EffectiveFrom && w.EffectiveTill == null).FirstOrDefault(); 

                            if (wr_rl == null)
                            {
                                var isWardRateExist = db.GtEswrrl.Where(x => x.BusinessKey == bl.BusinessKey && x.WardId == bl.WardId && x.RoomId == bl.RoomId
                                && x.RateType == bl.RateType && x.EffectiveFrom >= bl.EffectiveFrom).Count();
                                if (isWardRateExist > 0)
                                {
                                    return new DO_ReturnParameter() { Status = false, Message = "Rate already Exists For Entered EffectiveFrom." };
                                }

                                GtEswrrl ou_wrrl = db.GtEswrrl.Where(w => w.BusinessKey == bl.BusinessKey && w.WardId == bl.WardId && w.RoomId == bl.RoomId
                                && w.RateType == bl.RateType && w.EffectiveTill == null).FirstOrDefault();
                                if (ou_wrrl != null)
                                {
                                    ou_wrrl.EffectiveTill = bl.EffectiveFrom.AddDays(-1);
                                    ou_wrrl.ModifiedBy = bl.UserID;
                                    ou_wrrl.ModifiedOn = System.DateTime.Now;
                                    ou_wrrl.ModifiedTerminal = bl.TerminalID;
                                }

                                var o_wrrl = new GtEswrrl
                                {
                                    BusinessKey = bl.BusinessKey,
                                    WardId = bl.WardId,
                                    RoomId = bl.RoomId,
                                    RateType = bl.RateType,
                                    EffectiveFrom = bl.EffectiveFrom,
                                    Tariff = bl.Tariff,
                                    DayCareTariff = bl.DayCareTariff,
                                    ServiceChargePerc = bl.ServiceChargePerc,
                                    ActiveStatus = bl.ActiveStatus,
                                    FormId = bl.FormId,
                                    CreatedBy = bl.UserID,
                                    CreatedOn = System.DateTime.Now,
                                    CreatedTerminal = bl.TerminalID,
                                };
                                db.GtEswrrl.Add(o_wrrl);
                            }
                            else if (wr_rl != null)
                            {
                                wr_rl.Tariff = bl.Tariff;
                                wr_rl.DayCareTariff = bl.DayCareTariff;
                                wr_rl.ServiceChargePerc = bl.ServiceChargePerc;
                                wr_rl.ActiveStatus = bl.ActiveStatus;
                                wr_rl.ModifiedBy = bl.UserID;
                                wr_rl.ModifiedOn = System.DateTime.Now;
                                wr_rl.ModifiedTerminal = bl.TerminalID;
                            }
                            await db.SaveChangesAsync();
                        }

                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_WardRateLink>> GetWardEffectiveRateByBkRateType(int businessKey, int rateType)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_rl = db.GtEswrbl
                        .GroupJoin(db.GtEswrrl.Where(w => w.BusinessKey == businessKey && w.RateType == rateType && w.EffectiveTill == null && w.ActiveStatus),
                        b => new { b.BusinessKey, b.WardId, b.RoomId },
                        l => new { l.BusinessKey, l.WardId, l.RoomId },
                        (b, l) => new { b, l = l.FirstOrDefault() })//.DefaultIfEmpty()
                        .GroupJoin(db.GtEswrms,
                        bl => new { bl.b.WardId },
                        m => new { m.WardId },
                        (bl, m) => new { bl, m = m.FirstOrDefault() })//.DefaultIfEmpty()
                        .GroupJoin(db.GtEswrrm,
                        blm => new { blm.bl.b.RoomId },
                        rm => new { rm.RoomId },
                        (blm, rm) => new { blm, rm = rm.FirstOrDefault() })//.DefaultIfEmpty()
                        .Where(w => w.blm.bl.b.BusinessKey == businessKey && w.blm.bl.b.ActiveStatus)
                        .AsNoTracking()
                        .Select(r => new DO_WardRateLink
                        {
                            WardId = r.blm.bl.b.WardId,
                            WardDesc = r.blm.m.WardDesc,
                            RoomId = r.blm.bl.b.RoomId,
                            RoomDesc = r.rm.RoomDesc,
                            FromDate = r.blm.bl.l != null ? ((DateTime?)r.blm.bl.l.EffectiveFrom)  : null,
                            Tariff = r.blm.bl.l != null ? r.blm.bl.l.Tariff : 0,
                            DayCareTariff = r.blm.bl.l != null ? r.blm.bl.l.DayCareTariff : 0,
                            EffectiveTill = r.blm.bl.l != null ? r.blm.bl.l.EffectiveTill : null,
                            ServiceChargePerc = r.blm.bl.l != null ? r.blm.bl.l.ServiceChargePerc : 0,
                            ActiveStatus = r.blm.bl.l != null ? r.blm.bl.l.ActiveStatus : true
                        }).ToListAsync();

                    return await wr_rl;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<DO_WardRateLink>> GetWardPreviousRateByBkRateType(int businessKey, int rateType)
        {
            using (var db = new eSyaEnterprise())
            {
                try
                {
                    var wr_rl = db.GtEswrrl
                        .GroupJoin(db.GtEswrms,
                        l => new { l.WardId },
                        m => new { m.WardId },
                        (l, m) => new { l, m = m.FirstOrDefault() })
                        .GroupJoin(db.GtEswrrm,
                        lm => new { lm.l.RoomId },
                        rm => new { rm.RoomId },
                        (lm, rm) => new { lm, rm = rm.FirstOrDefault() })
                        .Where(w => w.lm.l.BusinessKey == businessKey && w.lm.l.RateType == rateType && w.lm.l.EffectiveTill != null && w.lm.l.ActiveStatus)
                        .AsNoTracking()
                        .Select(r => new DO_WardRateLink
                        {
                            WardId = r.lm.l.WardId,
                            WardDesc = r.lm.m.WardDesc,
                            RoomId = r.lm.l.RoomId,
                            RoomDesc = r.rm.RoomDesc,
                            FromDate = r.lm.l.EffectiveFrom,
                            Tariff = r.lm.l.Tariff,
                            DayCareTariff = r.lm.l.DayCareTariff,
                            EffectiveTill = r.lm.l.EffectiveTill,
                            ServiceChargePerc = r.lm.l.ServiceChargePerc,
                            ActiveStatus = r.lm.l.ActiveStatus
                        }).ToListAsync();

                    return await wr_rl;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception(CommonMethod.GetValidationMessageFromException(ex));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion Ward Rate Link
    }
}
