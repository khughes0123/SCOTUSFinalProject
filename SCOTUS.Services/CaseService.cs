﻿using SCOTUS.Data;
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
                                    CreatedUTC = e.CreatedUTC
                                }
                        );

                return query.ToArray();
            }
        }
    }
}