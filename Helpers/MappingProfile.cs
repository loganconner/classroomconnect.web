using ClassroomConnect.Web.Models.ViewModels;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FamilyDetailVM, EnrollmentRecordVM>();
            CreateMap<FamilyDetailVM, GuardianVM>();
            CreateMap<FamilyDetailVM, ChildVM>();
        }
    }
}
