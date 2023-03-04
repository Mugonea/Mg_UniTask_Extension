///////////////////////////////////////////////////////////////////////////////////////////
// Copyright 2023 Mugonea. All Rights Reserved.
///////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
    public partial struct UniTask
    {
        public static void VoidMain(Action action)
        {
            RunOnMain(action, false, default).Forget();
        }
        public static void VoidMain(Func<UniTaskVoid> action)
        {
            RunOnMain(action, false, default).Forget();
        }

        public static async UniTask RunOnMain(Action action, bool configureAwait = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UniTask.SwitchToMainThread();

            cancellationToken.ThrowIfCancellationRequested();

            if (configureAwait)
            {
                try
                {
                    action();
                }
                finally
                {
                    await UniTask.Yield();
                }
            }
            else
            {
                action();
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        public static async UniTask RunOnMain(Func<UniTask> action, bool configureAwait = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UniTask.SwitchToMainThread();

            cancellationToken.ThrowIfCancellationRequested();

            if (configureAwait)
            {
                try
                {
                    await action();
                }
                finally
                {
                    await UniTask.Yield();
                }
            }
            else
            {
                await action();
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        public static async UniTask<T> RunOnMain<T>(Func<T> action, bool configureAwait = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UniTask.SwitchToMainThread();

            cancellationToken.ThrowIfCancellationRequested();

            T result;

            if (configureAwait)
            {
                try
                {
                    result = action();
                }
                finally
                {
                    await UniTask.Yield();
                }
            }
            else
            {
                result = action();
            }

            cancellationToken.ThrowIfCancellationRequested();

            return result;
        }

        public static async UniTask<T> RunOnMain<T>(Func<UniTask<T>> action, bool configureAwait = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UniTask.SwitchToMainThread();

            cancellationToken.ThrowIfCancellationRequested();

            T result;

            if (configureAwait)
            {
                try
                {
                    result = await action();
                }
                finally
                {
                    await UniTask.Yield();
                }
            }
            else
            {
                result = await action();
            }

            cancellationToken.ThrowIfCancellationRequested();

            return result;
        }

        public static async UniTask RunOnMain(Func<UniTaskVoid> action, bool configureAwait = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UniTask.SwitchToMainThread();

            cancellationToken.ThrowIfCancellationRequested();

            if (configureAwait)
            {
                try
                {
                    action();
                }
                finally
                {
                    await UniTask.Yield();
                }
            }
            else
            {
                action();
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}