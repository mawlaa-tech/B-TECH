using AutoMapper;
using Boutique.Services.CouponAPI.Data;
using Boutique.Services.CouponAPI.Models;
using Boutique.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Boutique.Services.CouponAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CouponAPIController : Controller
{
 private readonly AppDbContext _db;
    private ResponseDto _response;
    private IMapper _mapper;
 public CouponAPIController(AppDbContext db, IMapper mapper1) { 
        _db = db;
        _response = new ResponseDto();
        _mapper = mapper1;
        }
    [HttpGet]
    public ResponseDto Get()
    {
        try
        {
            IEnumerable<Coupon> objetList = _db.Coupons.ToList();
           
            _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objetList);
                
        }
        catch (Exception ex)
        {
            _response.Messqge = ex.Message;
            _response.IsSuccess = false;
           
        }
        return _response;
    }
    [HttpGet]
    [Route("{id:int}")]
    public ResponseDto Get(int id)
    {
        try
        {
            Coupon obj = _db.Coupons.First(u => u .CouponId == id);

            _response.Result = _mapper.Map<CouponDto>(obj);
           


        }
        catch (Exception ex)
        {
            _response.IsSuccess=false;
            _response.Messqge=ex.Message;   
            
        }
        return _response;
    }

    [HttpGet]
    [Route("GetByCopde/{code}")]
    public ResponseDto Get(string code)
    {
        try
        {
            Coupon obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());

            _response.Result = _mapper.Map<CouponDto>(obj);



        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Messqge = ex.Message;

        }
        return _response;
    }

    [HttpPost]
    public ResponseDto Post([FromBody] CouponDto couponDto)
    {
        try
        {
            Coupon obj = _mapper.Map<Coupon>(couponDto);
            _db.Coupons.Add(obj);
            _db.SaveChanges();

            _response.Result = _mapper.Map<CouponDto>(obj);



        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Messqge = ex.Message;

        }
        return _response;
    }

    [HttpPut]
    public ResponseDto Put([FromBody] CouponDto couponDto)
    {
        try
        {
            Coupon obj = _mapper.Map<Coupon>(couponDto);
            _db.Coupons.Update(obj);
            _db.SaveChanges();

            _response.Result = _mapper.Map<CouponDto>(obj);



        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Messqge = ex.Message;

        }
        return _response;
    }

    [HttpDelete]
    public ResponseDto Delete(int id)
    {
        try
        {
            Coupon obj = _db.Coupons.First(u => u.CouponId == id);
            _db.Coupons.Remove(obj);
            _db.SaveChanges();

            _response.Result = _mapper.Map<CouponDto>(obj);



        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Messqge = ex.Message;

        }
        return _response;
    }
}
