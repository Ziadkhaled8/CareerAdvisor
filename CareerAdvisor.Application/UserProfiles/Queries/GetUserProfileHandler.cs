using AutoMapper;
using CareerAdvisor.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAdvisor.Application.UserProfiles.Queries
{
    //public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto?>
    //{
    //    private readonly ApplicationDbContext _context;
    //    private readonly IMapper _mapper;

    //    public GetUserProfileHandler(ApplicationDbContext context, IMapper mapper)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    public async Task<UserProfileDto?> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    //    {
    //        var profile = await _context.UserProfiles
    //            .AsNoTracking()
    //            .FirstOrDefaultAsync(p => p.UserId == request.UserId, cancellationToken);

    //        return profile == null ? null : _mapper.Map<UserProfileDto>(profile);
    //    }
    //}
}
