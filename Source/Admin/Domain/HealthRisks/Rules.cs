/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Domain.HealthRisks
{
    public delegate bool IsWithinNumberOfHealthRisksLimit(Guid projectId);
    public delegate bool IsHealthRiskUniqueWithinProject(Guid healthRiskId, Guid projectId);
    public delegate bool IsHealthRiskExisting(Guid healthRiskId);
}