﻿using AutoMapper;
using GB.ApiDotNet6.Application.DTOs;
using GB.ApiDotNet6.Application.DTOs.Validations;
using GB.ApiDotNet6.Application.Services.Interfaces;
using GB.ApiDotNet6.Domain.Entities;
using GB.ApiDotNet6.Domain.Repositories;
using System;

namespace GB.ApiDotNet6.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");

            var result = new PersonDtoValidator().Validate(personDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validade", result);

            var person = _mapper.Map<Person>(PersonDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));

        }
    }
}