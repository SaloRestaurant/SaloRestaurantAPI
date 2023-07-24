﻿using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace SaloAPI.BusinessLogic.ApiCommands;

public class CommonImageValidator : AbstractValidator<IFormFile>
{
    private readonly List<string> allowedExtensions = new()
    {
        "jpg", "JPG", "png", "PNG",
    };

    public CommonImageValidator()
    {
        RuleFor(x => x.Length)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .LessThanOrEqualTo(3 * 1024 * 1024)
            .WithMessage("Image file should not exceed 3 MB.");

        RuleFor(x => x.FileName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(HaveAllowedExtension)
            .WithMessage(
                $"File extension is not allowed. Allowed extensions: {string.Join(", ", allowedExtensions)}.")
            .Length(1, 50);
    }

    private bool HaveAllowedExtension(string str)
    {
        var extension = str.Split('.').Last();
        return allowedExtensions.Contains(extension);
    }
}