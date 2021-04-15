using SCOTUS.Data;
using SCOTUS.Models;
using SCOTUS.Models.CourtMembersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Services
{
    public class CourtMembersService
    {
        private readonly Guid _userId;

        public CourtMembersService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCourtMembers(CourtMembersCreate model)
        {
            var entity = new CourtMembers()

            {
                UserId = _userId,
                JusticeOneChiefJustice = model.JusticeOneChiefJustice,
                JusticeTwo = model.JusticeTwo,
                JusticeThree = model.JusticeThree,
                JusticeFour = model.JusticeFour,
                JusticeFive = model.JusticeFive,
                JusticeSix = model.JusticeSix,
                JusticeSeven = model.JusticeSeven,
                JusticeEight = model.JusticeEight,
                JusticeNine = model.JusticeNine,
                JusticeTen = model.JusticeTen


            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CourtMembers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CourtMembersListItem> GetCourts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CourtMembers
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CourtMembersListItem
                                {
                                    CourtId = e.CourtId,
                                    JusticeOneChiefJustice = e.JusticeOneChiefJustice,
                                    JusticeTwo = e.JusticeTwo,
                                    JusticeThree = e.JusticeThree,
                                    JusticeFour = e.JusticeFour,
                                    JusticeFive = e.JusticeFive,
                                    JusticeSix = e.JusticeSix,
                                    JusticeSeven = e.JusticeSeven,
                                    JusticeEight = e.JusticeEight,
                                    JusticeNine = e.JusticeNine,
                                    JusticeTen = e.JusticeTen
                                }
                        );

                return query.ToArray();
            }
        }

        public CourtMembersDetail GetCourtById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var en =
                    ctx
                        .CourtMembers
                        .Single(e => e.CourtId == id && e.UserId == _userId);
                return
                    new CourtMembersDetail
                    {
                        CourtId = en.CourtId,
                        JusticeOneChiefJustice = en.JusticeOneChiefJustice,
                        JusticeTwo = en.JusticeTwo,
                        JusticeThree = en.JusticeThree,
                        JusticeFour = en.JusticeFour,
                        JusticeFive = en.JusticeFive,
                        JusticeSix = en.JusticeSix,
                        JusticeSeven = en.JusticeSeven,
                        JusticeEight = en.JusticeEight,
                        JusticeNine = en.JusticeNine,
                        JusticeTen = en.JusticeTen

                    };
            }
        }

        public bool UpdateCourtMembers(CourtMembersEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CourtMembers
                        .Single(e => e.CourtId == id && e.UserId == _userId);

                entity.JusticeOneChiefJustice = model.JusticeOneChiefJustice;
                entity.JusticeTwo = model.JusticeTwo;
                entity.JusticeThree = model.JusticeThree;
                entity.JusticeFour = model.JusticeFour;
                entity.JusticeFive = model.JusticeFive;
                entity.JusticeSix = model.JusticeSix;
                entity.JusticeSeven = model.JusticeSeven;
                entity.JusticeEight = model.JusticeEight;
                entity.JusticeNine = model.JusticeNine;
                entity.JusticeTen = model.JusticeTen;
                    entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCourt(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CourtMembers
                        .Single(e => e.CourtId == id && e.UserId == _userId);

                ctx.CourtMembers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

