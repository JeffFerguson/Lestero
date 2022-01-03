namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// The function of LDA operator is to load a byte of memory into the accumulator and setting
    /// the zero and negative flags as appropriate.
    /// </summary>
    /// <remarks>
    /// Flags
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class LoadAccumulatorWithMemoryZeroPage : InstructionWithByteOperand
    {
        internal LoadAccumulatorWithMemoryZeroPage(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.ZeroPage, "LDA", 0xA5, 2, 3)
        {
        }

        internal override void Execute()
        {
            var newValue = this.Machine.ZeroPage[this.Operand];
            ManageNegativeFlag(this.Machine.Accumulator, newValue);
            this.Machine.Accumulator = newValue;
            ManageZeroFlag(newValue);
        }
    }
}
