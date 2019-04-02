﻿namespace MOE.Common.Models.Repositories
{
    public class SpeedEventRepositoryFactory
    {
        private static ISpeedEventRepository _speedEventRepository;

        public static ISpeedEventRepository Create()
        {
            if (_speedEventRepository != null)
                return _speedEventRepository;
            return new SpeedEventRepository();
        }

        public static void SetSignalsRepository(ISpeedEventRepository newRepository)
        {
            _speedEventRepository = newRepository;
        }
    }
}