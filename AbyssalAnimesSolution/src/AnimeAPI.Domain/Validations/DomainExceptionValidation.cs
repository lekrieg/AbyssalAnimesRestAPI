// ////////////////////////
// File: ValidateDomain.cs
// Created at: 11 24, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 24, 2023
// ////////////////////////

using System;

namespace AnimeAPI.Domain.Validations;

public class DomainExceptionValidation : Exception
{
	public DomainExceptionValidation(string error) : base(error)
	{
		
	}

	public static void When(bool hasError, string error)
	{
		if (hasError)
		{
			throw new DomainExceptionValidation(error);
		}
	}
}