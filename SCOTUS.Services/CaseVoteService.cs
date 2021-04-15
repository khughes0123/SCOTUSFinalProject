using SCOTUS.Data;
using SCOTUS.Models;
using SCOTUS.Models.CaseVoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOTUS.Services
{
    public class CaseVoteService
    {
        private readonly Guid _userId;

        public CaseVoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCaseVote(CaseVoteCreate model)
        {
            var entity = new CaseVote()

            {
                UserId = _userId,
                CourtDecision = model.CourtDecision,
                CourtId = model.CourtId,
                CaseId = model.CaseId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CaseVotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CaseVoteListItem> GetCaseVotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CaseVotes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CaseVoteListItem
                                {
                                    CaseVoteId = e.CaseVoteId,
                                    CourtId = e.CourtId,
                                    CaseId = e.CaseId,
                                    CourtDecision = e.CourtDecision,
                                    JusticeOneChiefJustice = e.Court.JusticeOneChiefJustice,
                                    JusticeTwo = e.Court.JusticeTwo,
                                    JusticeThree = e.Court.JusticeThree,
                                    JusticeFour = e.Court.JusticeFour,
                                    JusticeFive = e.Court.JusticeFive,
                                    JusticeSix = e.Court.JusticeSix,
                                    JusticeSeven = e.Court.JusticeSeven,
                                    JusticeEight = e.Court.JusticeEight,
                                    JusticeNine = e.Court.JusticeNine,
                                    JusticeTen = e.Court.JusticeTen
                                }
                        );

                return query.ToArray();
            }
        }

        public CaseVoteDetail GetCaseVoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CaseVotes
                        .Single(e => e.CaseVoteId == id && e.UserId == _userId);
                return
                    new CaseVoteDetail
                    {
                        CaseVoteId = entity.CaseVoteId,
                        CourtDecision = entity.CourtDecision,
                        CaseId = entity.CaseId,
                        Summary = entity.Case.Summary,
                        CourtId = entity.CourtId,
                        JusticeOneChiefJustice = entity.Court.JusticeOneChiefJustice,
                        JusticeTwo = entity.Court.JusticeTwo,
                        JusticeThree = entity.Court.JusticeThree,
                        JusticeFour = entity.Court.JusticeFour,
                        JusticeFive = entity.Court.JusticeFive,
                        JusticeSix = entity.Court.JusticeSix,
                        JusticeSeven = entity.Court.JusticeSeven,
                        JusticeEight = entity.Court.JusticeEight,
                        JusticeNine = entity.Court.JusticeNine,
                        JusticeTen = entity.Court.JusticeTen

                    };
            }
        }

        public bool UpdateCaseVote(CaseVoteEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CaseVotes
                        .Single(e => e.CaseVoteId == id && e.UserId == _userId);

                entity.CourtDecision = model.CourtDecision;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteCaseVote(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CaseVotes
                        .Single(e => e.CaseVoteId == id && e.UserId == _userId);

                ctx.CaseVotes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}