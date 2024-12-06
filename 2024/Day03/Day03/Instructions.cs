namespace Day03;

public record Instruction;
public record MulInstruction(int Left, int Right) : Instruction;
public record DoInstruction() : Instruction;

public record DontInstruction() : Instruction;
