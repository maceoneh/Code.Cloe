﻿using Code.Cloe.Application.Interfaces;
using Code.Cloe.Application.Services;
using Code.Cloe.Domain.Models;
using Code.Cloe.Infrastructure.Repository;
using Code.Cloe.Infrastructure.Repository.Contexts;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Cloe.Infrastructure.Factories.Services
{
    static public class Create
    {
        static public string? RepositoryFolder { get; set; }
        static public IServiceBase<TEntity, Guid> ServiceBase<TEntity>() where TEntity : class
        {
            RepositoryContext repository;
            if (RepositoryFolder == null)
            {
                repository = new RepositoryContext();
            }
            else
            {
                repository = new RepositoryContext(RepositoryFolder);
            }
            var entityType = typeof(TEntity);
            if (entityType == typeof(Subject))
            {
                var subject_repository = new SubjectRepository(repository);
                return (IServiceBase<TEntity, Guid>)new SubjectService(subject_repository);
            }
            throw new ArgumentException();
        }
    }
}
