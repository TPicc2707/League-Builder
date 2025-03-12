﻿global using Game.Domain.Models;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using BuildingBlocks.Behaviors;
global using BuildingBlocks.CQRS;
global using BuildingBlocks.Exceptions;
global using BuildingBlocks.Messaging.Events;
global using BuildingBlocks.Messaging.MassTransit;
global using BuildingBlocks.Pagination;
global using FluentValidation;
global using Game.Application.Dtos;
global using Game.Application.Data;
global using Game.Domain.ValueObjects;
global using Game.Application.Exceptions;
global using Game.Application.Leagues.Commands.CreateLeague;
global using MassTransit;
global using MediatR;
global using Microsoft.Extensions.Logging;
global using Game.Application.Leagues.Commands.DeleteLeague;
global using Game.Application.Leagues.Commands.UpdateLeague;
global using Game.Application.Seasons.Commands.CreateSeason;
global using Game.Application.Seasons.Commands.DeleteSeason;
global using Game.Application.Seasons.Commands.UpdateSeason;
global using Game.Application.Teams.Commands.CreateTeam;
global using Game.Application.Teams.Commands.DeleteTeam;
global using Game.Application.Teams.Commands.UpdateTeam;
global using Game.Domain.Enum;
global using Game.Application.Extensions;
