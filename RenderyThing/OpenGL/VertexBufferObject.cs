using Silk.NET.OpenGL;

namespace RenderyThing.OpenGL;

unsafe readonly struct VertexBufferObject : IDisposable
{
    readonly GL _gl;
    readonly uint _handle;
    readonly BufferUsageARB _bufferUsage;
    public VertexBufferObject(GL gl, BufferUsageARB bufferUsage)
    {
        _gl = gl;
        _handle = gl.GenBuffer();
        _bufferUsage = bufferUsage;
        Bind();
    }
    
    public void BufferData(ReadOnlySpan<float> data)
    {
        _gl.BufferData(BufferTargetARB.ArrayBuffer, data, _bufferUsage);
    }

    public void BufferSubData(nint offset, ReadOnlySpan<float> data)
    {
        _gl.BufferSubData(BufferTargetARB.ArrayBuffer, offset * sizeof(float), data);
    }

    public void Bind()
    {
        _gl.BindBuffer(BufferTargetARB.ArrayBuffer, _handle);
    }

    public void Dispose()
    {
        _gl.DeleteBuffer(_handle);
    }
}
