﻿namespace MOE.Common.Models.Repositories
{
    public class ApproachRepositoryFactory
    {
        private static IApproachRepository approachRepository;

        public static IApproachRepository Create()
        {
            if (approachRepository != null)
                return approachRepository;
            return new ApproachRepository();
        }

        public static IApproachRepository Create(SPM context)
        {
            if (approachRepository != null)
                return approachRepository;
            return new ApproachRepository(context);
        }

        public static void SetApproachRepository(IApproachRepository newRepository)
        {
            approachRepository = newRepository;
        }
    }
}