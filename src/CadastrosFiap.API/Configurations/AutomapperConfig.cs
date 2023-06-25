using AutoMapper;
using CadastrosFiap.API.ViewModels;
using CadastrosFiap.Business.Models;

namespace CadastrosFiap.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Turma, TurmaViewModel>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaViewModel>().ReverseMap();
            //CreateMap<AlunoTurma, AlunoTurmaViewModel>().ForMember(a => a.Aluno, x => x.Ignore());
            //CreateMap<AlunoTurmaViewModel, AlunoTurma>().ForMember(a => a.Aluno, x => x.Ignore());

        }
    }
}
