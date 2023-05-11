using Microsoft.EntityFrameworkCore;
using eSyaInPatient.DL.Entities;
using eSyaInPatient.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaInPatient.IF;

namespace eSyaInPatient.DL.Repository
{
    public class CommonDataRepository : ICommonDataRepository
    {
        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeType(int codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcd
                        .Where(w => w.CodeType == codeType && w.ActiveStatus)
                        .Select(r => new DO_ApplicationCodes
                        {
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_ApplicationCodes>> GetApplicationCodesByCodeTypeList(List<int> l_codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = db.GtEcapcd
                        .Where(w => w.ActiveStatus
                        && l_codeType.Contains(w.CodeType))
                        .Select(r => new DO_ApplicationCodes
                        {
                            CodeType = r.CodeType,
                            ApplicationCode = r.ApplicationCode,
                            CodeDesc = r.CodeDesc
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return await ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_BusinessLocation>> GetBusinessKey()
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var bk = db.GtEcbsln
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            LocationDescription = r.LocationDescription,
                            SegmentDesc = r.GtEcbssg.SegmentDesc
                        }).ToListAsync();

                    return await bk;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_StoreMaster>> GetStoreList(int businessKey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var st_ms = db.GtEastbl
                        .Join(db.GtEcstrm,
                        b => new { b.StoreCode },
                        s => new { s.StoreCode },
                        (b, s) => new { b, s})
                        .Where(w => w.b.BusinessKey == businessKey && w.b.ActiveStatus)
                        .AsNoTracking()
                        .Select(r => new DO_StoreMaster
                        {
                            StoreCode = r.b.StoreCode,
                            StoreDesc = r.s.StoreDesc
                        }).ToListAsync();

                    return await st_ms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
