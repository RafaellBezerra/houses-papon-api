﻿using HousesPapon.Communication.Responses.Images;

namespace HousesPapon.Application.UseCases.Images.GetAll
{
    public interface IGetAllImagesUseCase
    {
        Task<List<ResponseGetAllImages>> Execute();
    }
}
