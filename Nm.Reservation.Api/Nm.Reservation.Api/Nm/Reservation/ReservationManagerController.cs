using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Nm.Reservation
{
    [ApiController]
    [Route("api/Reservation/ReservationManagerInfo")]
    public class ReservationManagerInfoController : AbpController
    {
        private readonly IReservationManagerInfoAppService _resMangerAppService;
        public ReservationManagerInfoController(
            IReservationManagerInfoAppService resMangerAppService)
        {
            _resMangerAppService = resMangerAppService;
        }
        [HttpPost]
        public ReservationManagerInfoDto Create(ReservationManagerInfoCreateOrupdateDto inputDto)
        {
            return _resMangerAppService.Create(inputDto);
        }
        [HttpGet]
        public PagedResultDto<ReservationManagerInfoDto> GetListByName(GetReservationManagerInfosInput input)
        {
            return _resMangerAppService.GetListByName(input);
        }
        [HttpGet]
        public PagedResultDto<ReservationManagerInfoDto> GetList(GetReservationManagerInfosInput input)
        {
            return _resMangerAppService.GetList(input);
        }
        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _resMangerAppService.Delete(id);
        }
        [HttpPut]
        [Route("{id}")]
        public ReservationManagerInfoDto Update(Guid id, ReservationManagerInfoCreateOrupdateDto inputDto)
        {
            return _resMangerAppService.Update(id, inputDto);
        }
    }
}
