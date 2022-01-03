namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    internal class BranchOnResultMinus : InstructionWithByteOperand
    {
        internal BranchOnResultMinus(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Relative, "BMI", 0x30, 2, 2)
        {
        }
    }
}
