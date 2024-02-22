﻿using AutoMapper;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;

namespace LaboratoryExperiments.Web.Data.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Station, StationViewModel>().ForMember(des=>des.ProcessingType,op=>op.MapFrom(src=>src.ProcessingType.Name)).
                ForMember(des => des.StationStatus, op => op.MapFrom(src => src.StationStatus.Name))
                .ForMember(des => des.ProcessingType, op => op.MapFrom(src => src.ProcessingType.Name))
                .ForMember(des => des.Branch, op => op.MapFrom(src => src.Branch.Name))
                .ForMember(des => des.SanitaryDrain, op => op.MapFrom(src => src.SanitaryDrain.Name))
                .ForMember(des => des.ProcessingSystem, op => op.MapFrom(src => src.ProcessingSystem.Name));
        }
    }
}