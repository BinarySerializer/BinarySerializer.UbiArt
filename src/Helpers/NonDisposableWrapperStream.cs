﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BinarySerializer.UbiArt
{
    internal class NonDisposableWrapperStream : Stream
    {
        public NonDisposableWrapperStream(Stream baseStream)
        {
            BaseStream = baseStream;
        }

        public Stream BaseStream { get; }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) =>
            BaseStream.CopyToAsync(destination, bufferSize, cancellationToken);

        // Do nothing
        public override void Close() { }
        protected override void Dispose(bool disposing) { }

        public override void Flush() => BaseStream.Flush();
        public override Task FlushAsync(CancellationToken cancellationToken) => BaseStream.FlushAsync(cancellationToken);

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) =>
            BaseStream.BeginRead(buffer, offset, count, callback, state);

        public override int EndRead(IAsyncResult asyncResult) => BaseStream.EndRead(asyncResult);

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            BaseStream.ReadAsync(buffer, offset, count, cancellationToken);

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) =>
            BaseStream.BeginWrite(buffer, offset, count, callback, state);

        public override void EndWrite(IAsyncResult asyncResult) => BaseStream.EndWrite(asyncResult);

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
            BaseStream.WriteAsync(buffer, offset, count, cancellationToken);

        public override long Seek(long offset, SeekOrigin origin) => BaseStream.Seek(offset, origin);

        public override void SetLength(long value) => BaseStream.SetLength(value);

        public override int Read(byte[] buffer, int offset, int count) => BaseStream.Read(buffer, offset, count);
        public override int ReadByte() => BaseStream.ReadByte();

        public override void Write(byte[] buffer, int offset, int count) => BaseStream.Write(buffer, offset, count);
        public override void WriteByte(byte value) => BaseStream.WriteByte(value);

        public override bool CanRead => BaseStream.CanRead;
        public override bool CanSeek => BaseStream.CanSeek;
        public override bool CanTimeout => BaseStream.CanTimeout;
        public override bool CanWrite => BaseStream.CanWrite;
        public override long Length => BaseStream.Length;
        public override long Position
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }

        public override int ReadTimeout { get; set; }
        public override int WriteTimeout { get; set; }
    }
}