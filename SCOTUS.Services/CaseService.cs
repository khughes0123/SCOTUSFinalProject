using SCOTUS.Data;
using SCOTUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Services
{
    public class CaseService
    {
        private readonly Guid _userId;

        public CaseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCase(CaseCreate model)
        {
            var entity = new Case()

            {
                UserId = _userId,
                Title = model.Title,
                Summary = model.Summary,
                HouseControl = model.HouseControl,
                SenateControl = model.SenateControl,
                CaseYear = model.CaseYear,
                CreatedUTC = DateTimeOffset.Now


            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cases.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CaseListItem> GetCases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cases
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CaseListItem
                                {
                                    CaseId = e.CaseId,
                                    Title = e.Title,
                                    Summary = e.Summary,
                                    CaseYear = e.CaseYear,
                                    CreatedUTC = e.CreatedUTC,
                                    HouseControl= e.HouseControl,
                                    SenateControl=e.SenateControl
                                }
                        );

                return query.ToArray();
            }
        }

        public CaseDetail GetCaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cases
                        .Single(e => e.CaseId == id && e.UserId == _userId);
                return
                    new CaseDetail
                    {
                        CaseId = entity.CaseId,
                        Title = entity.Title,
                        Summary = entity.Summary,
                        HouseControl = entity.HouseControl,
                        SenateControl = entity.SenateControl,
                        CaseYear = entity.CaseYear,
                        CreatedUTC = entity.CreatedUTC,
                        ModifiedUTC = entity.ModifiedUTC
                    };
            }
        }

        public bool UpdateCase(CaseEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cases
                        .Single(e => e.CaseId == id && e.UserId == _userId);

                entity.Summary = model.Summary;
                entity.Title = model.Title;
                entity.CaseYear = model.CaseYear;
                entity.HouseControl = model.SenateControl;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCase(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cases
                        .Single(e => e.CaseId == id && e.UserId == _userId);

                ctx.Cases.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
