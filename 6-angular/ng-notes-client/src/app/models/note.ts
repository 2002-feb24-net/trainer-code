export default interface Note {
  id: number;
  isPublic: boolean;
  text?: string;
  dateModified: Date;
}
