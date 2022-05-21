using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaWebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorQuery
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authors);
            return vm;

        }

    }
    public class AuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
