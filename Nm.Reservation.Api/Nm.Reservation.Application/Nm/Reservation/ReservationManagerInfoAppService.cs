using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Nm.Reservation
{
    public class ReservationManagerInfoAppService : ReservationAppServiceBase, IReservationManagerInfoAppService
    {
        private readonly IReservationManagerInfoRepository _rmInfoRepository;
        public ReservationManagerInfoAppService(
            IReservationManagerInfoRepository rmInfoRepository)
        {
            _rmInfoRepository = rmInfoRepository;
        }
        public ReservationManagerInfoDto Create(ReservationManagerInfoCreateOrupdateDto inputDto)
        {
            var resManager =
                new ReservationManagerInfo(GuidGenerator.Create(), inputDto.Name, inputDto.OpenDays);
            CreateResCondition(inputDto.ConditionCreateDtos,
                resManager.ReservationConditions, resManager.Id);
            var resManagerDto = _rmInfoRepository.InsertAsync(resManager).Result;
            CurrentUnitOfWork.CompleteAsync();
            return ObjectMapper.Map<ReservationManagerInfo, ReservationManagerInfoDto>(resManagerDto);
        }
        public PagedResultDto<ReservationManagerInfoDto> GetListByName(GetReservationManagerInfosInput input, bool fuzzy = true)
        {
            var totalCount = _rmInfoRepository.GetCountAsync().Result;
            var rmInfo = ObjectMapper.Map<List<ReservationManagerInfo>, List<ReservationManagerInfoDto>>(
                _rmInfoRepository.GetListByName(input.Name, input.SkipCount, input.MaxResultCount, fuzzy));
            return new PagedResultDto<ReservationManagerInfoDto>(totalCount, rmInfo);
        }
        public PagedResultDto<ReservationManagerInfoDto> GetList(PagedAndSortedResultRequestDto input)
        {
            var totalCount = _rmInfoRepository.GetCountAsync().Result;
            var rmInfo = ObjectMapper.Map<List<ReservationManagerInfo>, List<ReservationManagerInfoDto>>(
                _rmInfoRepository.GetList(input.SkipCount, input.MaxResultCount));
            return new PagedResultDto<ReservationManagerInfoDto>(totalCount, rmInfo);
        }
        public void Delete(Guid id)
        {
            if (_rmInfoRepository.FindAsync(id).Result == null)
            {
                throw new EntityNotFoundException(typeof(ReservationManagerInfo), id);
            }
            _rmInfoRepository.DeleteAsync(id);
        }
        public ReservationManagerInfoDto Update(Guid id, ReservationManagerInfoCreateOrupdateDto inputDto)
        {
            var entity = _rmInfoRepository.FindAsync(id).Result;
            if (entity == null)
                throw new EntityNotFoundException(typeof(ReservationManagerInfo), entity.Id);
            entity.SetOpenDays(inputDto.OpenDays);
            entity.SetIncludeDay(inputDto.IncludeDay);
            return ObjectMapper.Map<ReservationManagerInfo, ReservationManagerInfoDto>(
                    _rmInfoRepository.UpdateAsync(entity).Result);
        }
        private void CreateResCondition(
            ICollection<ReservationConditionCreateDto> rcDtos,
            ICollection<ReservationCondition> rcList, Guid resManagerId)
        {
            if (rcDtos?.Count > 0)
            {
                foreach (var condition in rcDtos)
                {
                    var resCondition = new ReservationCondition(
                        GuidGenerator.Create(), condition.ItemName, condition.ItemValue, condition.RCType, resManagerId);
                    if (condition.RCType == ReservationConditionType.Period
                        && condition.ReservationPeriods?.Count > 0)
                    {
                        foreach (var period in condition.ReservationPeriods)
                        {
                            var rPeriod = new ReservationPeriod(GuidGenerator.Create(), period.StartTime, period.EndTime, period.Name, resCondition.Id);
                            resCondition.AddResPeriod(rPeriod);
                        }
                    }
                    if (condition.ReservationConditions?.Count > 0)
                        CreateResCondition(condition.ReservationConditions, resCondition.ChildResConditions, resManagerId);
                    rcList.Add(resCondition);
                }
            }
        }
    }
}