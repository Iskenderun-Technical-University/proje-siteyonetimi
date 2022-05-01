using AutoMapper;
using ResidenceManagement.Application.Features.Commands.Authentications.SignUpUser;
using ResidenceManagement.Application.Features.Commands.Authentications.UpdateUser;
using ResidenceManagement.Application.Features.Commands.DuesControl.AddDues;
using ResidenceManagement.Application.Features.Commands.DuesControl.AddDuesRange;
using ResidenceManagement.Application.Features.Commands.DuesControl.UpdateDues;
using ResidenceManagement.Application.Features.Commands.Invoices.AddInvoice;
using ResidenceManagement.Application.Features.Commands.Invoices.AddInvoiceRange;
using ResidenceManagement.Application.Features.Commands.Invoices.UpdateInvoice;
using ResidenceManagement.Application.Features.Commands.Messages.SendMessage;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDues;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDuesRange;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.UpdateResidenceDues;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoice;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoiceRange;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.UpdateResidenceInvoice;
using ResidenceManagement.Application.Features.Commands.Residences.AddResidence;
using ResidenceManagement.Application.Features.Commands.Residences.AddResidenceRange;
using ResidenceManagement.Application.Features.Commands.Residences.UpdateResidence;
using ResidenceManagement.Application.Features.Commands.UserResidences.AddUserResidence;
using ResidenceManagement.Application.Features.Commands.UserResidences.UpateUserResidence;
using ResidenceManagement.Application.Features.Queries.Authentications.SignInUser;
using ResidenceManagement.Application.Features.Queries.Messages.GetMessages;
using ResidenceManagement.Application.Features.Queries.UserResidences.GetUserResidenceByResident;
using ResidenceManagement.Application.Models.Messages;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Models.ResidenceDuesControl;
using ResidenceManagement.Application.Models.ResidenceInvoices;
using ResidenceManagement.Application.Models.Residences;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Application.Models.Users;
using ResidenceManagement.Domain.Entities.Auths;
using ResidenceManagement.Domain.Entities.Managements;


namespace ResidenceManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<SignUpUserCommand, User>().ReverseMap(); 
            CreateMap<SignInUserQuery, User>().ReverseMap();
            CreateMap<User, UserListModel>().ReverseMap(); 
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();

            #endregion


            #region Dto ve Tablo'daki verilerin property ismi farklı olanları eşleştirme
            CreateMap<ResidenceDto, Residence>().ReverseMap().ForMember(dest=>dest.ResidenceType,
                act=>act.MapFrom(src=>src.ResidenceType.Type));
           
            #endregion

            #region User Residence DTO
            CreateMap<UserResidenceDto, User>().ReverseMap();
            CreateMap<UserResidenceDto, UserResidence>().ReverseMap(); 
            CreateMap<UserResidenceDto, ResidentType>().ReverseMap();
            CreateMap<UserResidence, AddUserResidenceCommand>().ReverseMap();
            CreateMap<UserResidence, UpdateUserResidenceCommand>().ReverseMap();
            #endregion

            #region Residence
            CreateMap<Residence, AddResidenceCommand>().ReverseMap();
            CreateMap<Residence, ResidenceAddDto>().ReverseMap(); 
            CreateMap<Residence, AddResidenceRangeCommand>().ReverseMap();
            CreateMap<Residence, UpdateResidenceCommand>().ReverseMap();
            #endregion

            #region Resident
            CreateMap<UserResidence, GetResidenceByResidentQuery>().ReverseMap();
            #endregion

            #region Dues Control
            CreateMap<Dues, AddDuesCommand>().ReverseMap();
            CreateMap<Dues, PaymentDto>().ReverseMap();
            CreateMap<PaymentDto, Dues>().ReverseMap();

            CreateMap<AddDuesCommand, PaymentDto>().ReverseMap();
            CreateMap<Dues, UpdateDuesCommand>().ReverseMap();
            CreateMap<Dues, AddDuesRangeCommand>().ReverseMap();

            #endregion

            #region Invoices
            CreateMap<Invoice, AddInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, PaymentDto>().ReverseMap();
            CreateMap<PaymentDto, Invoice>().ReverseMap();

            CreateMap<AddInvoiceCommand, PaymentDto>().ReverseMap(); 
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, AddInvoiceRangeCommand>().ReverseMap();
            #endregion

            #region Residence Invoice
            CreateMap<ResidenceInvoice, AddResidenceInvoiceCommand>().ReverseMap(); 
            CreateMap<ResidenceInvoice, AddRangeResidenceInvoiceCommand>().ReverseMap(); 
            CreateMap<ResidenceInvoice, UpdateResidenceInvoiceCommand>().ReverseMap();
            CreateMap<ResidenceInvoice, ResidenceInvoiceDto>().ReverseMap();

            #endregion

            #region Residence Dues
            CreateMap<ResidenceDues, AddResidenceDuesCommand>().ReverseMap();
            CreateMap<ResidenceDues, AddRangeResidenceDuesCommand>().ReverseMap();
            CreateMap<ResidenceDues, UpdateResidenceDuesCommand>().ReverseMap(); 
            CreateMap<ResidenceDues, ResidenceDuesDto>().ReverseMap();


            #endregion

            #region Messages
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, SendMessageCommand>().ReverseMap();
            CreateMap<Message, GetMessageQuery>().ReverseMap();
            CreateMap<MessageDto, Message>().ReverseMap().ForMember(dest => dest.SenderEmail,
               act => act.MapFrom(src => src.Sender.Email))
                .ForMember(dest=>dest.ReceiverEmail,act=>act.MapFrom(src=>src.Receiver.Email));


            #endregion




        }
    }
}
