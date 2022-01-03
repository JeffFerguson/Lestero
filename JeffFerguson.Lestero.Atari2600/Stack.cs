namespace JeffFerguson.Lestero.Atari2600
{
    /// <summary>
    /// An implementation of the stack for the 6502 processor.
    /// </summary>
    /// <remarks>
    /// The 6502 family microprocessors use stack for basic storage such as storing the register content before interrupt, etc. The stack is
    /// located at the second 256 bytes ($0100 - $01FF) starting from $01FF. The Stack Pointer (SP) is an 8 bit register which is pointer to
    /// the low 8 bits ($FF - $00) of the next available memory between $01FF - $0100. The address of the stack is fixed and cannot be modified
    /// or re-allocated. The first data are stored at $01FF and so on. Pushing data to the stack causes the Stack Pointer (SP) to be decremented
    /// towards from $FF to $00 (mapping to address $01FF to $0100). Conversely pulling bytes causes it to be incremented towards form $00 to $FF.
    /// Please be noted that 6502 family microprocessor does not check if the Stack Pointer(SP) is decremented from $00. Decremented $00 by $1
    /// the Stack Pointer(SP) becomes $FF, thus the program will most likely result in crashing if the stack size is larger than $FF.
    /// </remarks>
    internal class Stack
    {
        private byte stackPointer;
        private readonly byte[] stackStorage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal Stack()
        {
            stackStorage = new byte[VirtualMachine.PageSize];
            stackPointer = (byte)(stackStorage.Length - 1);
        }

        /// <summary>
        /// Pushes a byte value onto the stack.
        /// </summary>
        /// <param name="value">
        /// The byte value to push onto the stack.
        /// </param>
        internal void Push(byte value)
        {
            stackStorage[stackPointer] = value;
            stackPointer--;
        }

        /// <summary>
        /// Pushes an unsigned short value onto the stack.
        /// </summary>
        /// <param name="value">
        /// The unsigned short value to push onto the stack.
        /// </param>
        internal void Push(ushort value)
        {
            Push((byte)(value >> 8));
            Push((byte)(value & 0xff));
        }
    }
}
