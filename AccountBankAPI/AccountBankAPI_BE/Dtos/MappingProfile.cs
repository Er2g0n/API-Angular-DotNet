using API.Models;
using AutoMapper;
using System.Globalization;


namespace API.Dtos;

public class MappingProfile :Profile
{
    public MappingProfile()
    {
        // Chuyển đổi dữ liệu từ model -> DTO : object -> JSON
        CreateMap<Account, AccountDTO>().ForMember(destination => destination.Password, opt => opt.Ignore()).ReverseMap();


        CreateMap< TransactionDetail, TransactionDetailDTO>().ForMember(  
      d => d.DateOfTrans,
      s => s.MapFrom(s => s.DateOfTrans.ToString( "dd/MM/yyyy" )))
     
        .ForMember(
      d => d.TransType,
      s => s.MapFrom(s => s.TransType == 1)
      );



        _ = CreateMap<TransactionDetailDTO, TransactionDetail>()
         .ForMember(
            d => d.DateOfTrans,
            s => s.MapFrom(s => DateTime.ParseExact(s.DateOfTrans, "dd/MM/yyyy", CultureInfo.InvariantCulture))
            )

            .ForMember(
            d => d.TransType,
            s => s.MapFrom(s => s.TransType == 0 ? 0 : 1)
            )
          ;
    }
}


