namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// BNE
    /// </summary>
    /// <remarks>
    /// N Z C I D V
    /// - -	- -	- -
    /// </remarks>
    internal class BranchOnResultNotZero : InstructionWithByteOperand
    {
        internal BranchOnResultNotZero(VirtualMachine vm, ushort address) : base(vm,address,  AddressingForm.Relative, "BNE", 0xD0, 2, 2)
        {
        }

        internal override void Execute()
        {
            if (this.Machine.ZeroFlag == false)
            {
                var pcOffset = GetTwosCompliment(this.Operand);
                var newPC = (short)this.RomAddress + pcOffset;
                this.Machine.ProgramCounter = (ushort)newPC;
            }
        }
    }
}
