namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    public enum AddressingForm
    {
        /// <summary>
        /// Address mode is unkonwn.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Operand is implied. For use with single byte instruction.
        /// </summary>
        Implied = 1,

        /// <summary>
        /// Operand is byte.
        /// </summary>
        Immediate = 2,

        /// <summary>
        /// Operand is zeropage address. Effective address is address incremented by X without carry.
        /// </summary>
        ZeroPageX = 3,

        /// <summary>
        /// Branch target is program counter + operand.
        /// </summary>
        Relative = 4,

        /// <summary>
        /// Operand is an absolute address.
        /// </summary>
        Absolute = 5,

        /// <summary>
        /// operand is zeropage address.
        /// </summary>
        ZeroPage = 6,

        /// <summary>
        /// operand is address; effective address is address incremented by Y with carry
        /// </summary>
        AbsoluteY = 7,

        /// <summary>
        /// operand is address; effective address is address incremented by X with carry
        /// </summary>
        AbsoluteX = 8,

        /// <summary>
        /// operand is zeropage address; effective address is word in (LL + X, LL + X + 1), inc. without carry: C.w($00LL + X)
        /// </summary>
        IndirectX = 9,

        /// <summary>
        /// operand is AC (implied single byte instruction)
        /// </summary>
        Accumulator = 10,

        /// <summary>
        /// operand is zeropage address; effective address is word in (LL, LL + 1) incremented by Y with carry: C.w($00LL) + Y
        /// </summary>
        IndirectY = 11
    }
}
