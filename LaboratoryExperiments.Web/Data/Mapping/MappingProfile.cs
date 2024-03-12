using AutoMapper;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;

namespace LaboratoryExperiments.Web.Data.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //station
            CreateMap<Station, StationViewModel>().ForMember(des=>des.ProcessingType,op=>op.MapFrom(src=>src.ProcessingType.Name)).
                ForMember(des => des.StationStatus, op => op.MapFrom(src => src.StationStatus.Name))
                .ForMember(des => des.ProcessingType, op => op.MapFrom(src => src.ProcessingType.Name))
                .ForMember(des => des.Branch, op => op.MapFrom(src => src.Branch.Name))
                .ForMember(des => des.SanitaryDrain, op => op.MapFrom(src => src.SanitaryDrain.Name))
                .ForMember(des => des.ProcessingSystem, op => op.MapFrom(src => src.ProcessingSystem.Name));

            CreateMap<CreateStationViewModel, Station>();

            //experiment
            CreateMap<Experiment, ExperimentViewModel>().ForMember(des => des.Unit, op => op.MapFrom(src => src.Unit.Name))
                .ForMember(des => des.ExperimentType, op => op.MapFrom(src => src.ExperimentType.Name));

            CreateMap<CreateExperimentViewModel, Experiment>();

            //test
            CreateMap<CreateTestViewModel, Test>();
            CreateMap<Test, TestViewModel>().ForMember(des => des.Station, op => op.MapFrom(src => src.Station.Name))
               .ForMember(des => des.Branch, op => op.MapFrom(src => src.Station.Branch.Name))
               .ForMember(des => des.Experiment, op => op.MapFrom(src => src.Experiment.Name))
               .ForMember(des => des.SanitaryDrain, op => op.MapFrom(src => src.Station.SanitaryDrain.Name))
               .ForMember(des => des.ExperimentType, op => op.MapFrom(src => src.Experiment.ExperimentType.Name))
                .ForMember(des => des.InffleuntValue, op => op.MapFrom(src => src.Experiment.InffleuntValue))
                 .ForMember(des => des.EffleuntValue, op => op.MapFrom(src => src.Experiment.EffleuntValue));


            CreateMap<Test, TestViewModel>().ForMember(des => des.Station, op => op.MapFrom(src => src.Station.Name))
             .ForMember(des => des.Branch, op => op.MapFrom(src => src.Station.Branch.Name))
             .ForMember(des => des.Experiment, op => op.MapFrom(src => src.Experiment.Name))
             .ForMember(des => des.SanitaryDrain, op => op.MapFrom(src => src.Station.SanitaryDrain.Name))
             .ForMember(des => des.ExperimentType, op => op.MapFrom(src => src.Experiment.ExperimentType.Name))
             .ForMember(des => des.InffleuntValue, op => op.MapFrom(src => src.Experiment.InffleuntValue))
             .ForMember(des => des.EffleuntValue, op => op.MapFrom(src => src.Experiment.EffleuntValue))
              .ForMember(des => des.InffleuntValueTo, op => op.MapFrom(src => src.Experiment.InffleuntValueTo))
             .ForMember(des => des.EffleuntValueTo, op => op.MapFrom(src => src.Experiment.EffleuntValueTo));
             

            CreateMap<Test, FilteredTestViewModel>().ForMember(des => des.Station, op => op.MapFrom(src => src.Station.Name))
              .ForMember(des => des.Branch, op => op.MapFrom(src => src.Station.Branch.Name))
              .ForMember(des => des.Experiment, op => op.MapFrom(src => src.Experiment.Name))
              .ForMember(des => des.SanitaryDrain, op => op.MapFrom(src => src.Station.SanitaryDrain.Name))
              .ForMember(des => des.ExperimentType, op => op.MapFrom(src => src.Experiment.ExperimentType.Name))   
               .ForMember(des => des.ReferenceValue, op => op.MapFrom(src =>  src.In_Eff?
               src.Experiment.EffleuntValueTo != null ? (object)src.Experiment.EffleuntValue +"-"+ src.Experiment.EffleuntValueTo : (object)src.Experiment.EffleuntValue
               :
               src.Experiment.InffleuntValueTo != null ? (object)src.Experiment.InffleuntValue + "-" + src.Experiment.InffleuntValueTo : (object)src.Experiment.InffleuntValue))
              .ForMember(des => des.In_EffWord, op => op.MapFrom(src => src.In_Eff? "Effleunt" : "Inffleunt"))
              .ForMember(des => des.ResultWord, op => op.MapFrom(src => src.Result ? "Identical" : "Not matching"))
              .ForMember(des => des.Datestring, op => op.MapFrom(src => src.Date.ToShortDateString()));



        }
    }
}
