namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// AND
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class AndMemoryWithAccumulatorImmediate : InstructionWithByteOperand
    {
        internal AndMemoryWithAccumulatorImmediate(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Immediate, "AND", 0x29, 2, 2)
        {
        }

        internal override void Execute()
        {
            var result = (byte)(this.Machine.Accumulator & this.Operand);
            ManageNegativeFlag(this.Machine.Accumulator, result);
            this.Machine.Accumulator = result;
            ManageZeroFlag(result);
        }
    }
}
