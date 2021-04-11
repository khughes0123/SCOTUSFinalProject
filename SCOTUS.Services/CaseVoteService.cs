using SCOTUS.Data;
using SCOTUS.Models;
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

        public IEnumerable<CaseVoteDetail> GetCaseVotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .CaseVotes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CaseVoteDetail
                                {
                                    CaseVoteId = e.CaseVoteId
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

                    };
            }
        }
    }
}