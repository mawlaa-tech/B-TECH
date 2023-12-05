using AutoMapper;
using Boutique.Services.CouponAPI.Models;
using Boutique.Services.CouponAPI.Models.Dto;

namespace Boutique.Services.CouponAPI;

public class MapingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mapingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CouponDto, Coupon>();
            config.CreateMap<Coupon, CouponDto>();
        });
        return mapingConfig;
        

    }
}
