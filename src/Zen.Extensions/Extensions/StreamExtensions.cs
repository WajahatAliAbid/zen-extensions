using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads buffer from a network stream asynchronously
        /// </summary>
        /// <param name="stream">Stream as received from <see cref="System.Net.Sockets.TcpClient"/></param>
        /// <param name="receiveBuffer">Buffer to receive data in</param>
        /// <param name="cancellationToken">Cancellation token to cancel the reading of buffer</param>
        /// <returns>number of bytes read</returns>
        internal static async Task<int> ReadBufferAsync(this Stream stream, Memory<byte> receiveBuffer, CancellationToken cancellationToken = default)
        {
            var cancellationTask = Task.Delay(-1, cancellationToken);
            var readBufferTask = stream.ReadAsync(receiveBuffer).AsTask();
            await Task.WhenAny(cancellationTask, readBufferTask);
            if (cancellationTask.IsCanceled)
            {
                throw new TaskCanceledException();
            }
            return await readBufferTask;
        }
    }
}