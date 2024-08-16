namespace Lib.Queue;


// 双向队列接口
public interface IDoubleQueue<TValue>
{
    /// <summary>
    /// 在队首插入元素
    /// </summary>
    /// <param name="value">要插入的元素</param>
    void PushFirst(TValue value);
    /// <summary>
    /// 在队尾插入元素
    /// </summary>
    /// <param name="value">要插入的元素</param>
    void PushLast(TValue value);

    /// <summary>
    /// 弹出队首元素
    /// </summary>
    /// <returns>成功返回队首元素.否则返回TValue默认值,如果是引用类型则为<see cref="null"/></returns>
    TValue? PopFirst();
    /// <summary>
    /// 弹出队尾元素
    /// </summary>
    /// <returns>成功返回队尾元素.否则返回TValue默认值,如果是引用类型则为<see cref="null"/></returns>
    TValue? PopLast();

    /// <summary>
    /// 查看队首元素但不弹出
    /// </summary>
    /// <returns>成功返回队首元素.否则返回TValue默认值,如果是引用类型则为<see cref="null"/></returns>
    TValue? PeekFirst();

    /// <summary>
    /// 查看队尾元素但不弹出
    /// </summary>
    /// <returns>成功返回队首元素.否则返回TValue默认值,如果是引用类型则为<see cref="null"/></returns>
    TValue? PeekLast();
}
