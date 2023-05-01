import { Profile } from "./Account.js"

export class Recipe {
  constructor(data) {
    this.id = data.id
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.creatorId = data.creatorId
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.creator = new Profile(data.creator)
  }
}

// public string Instructions { get; set; }
// public string Img { get; set; }
// public string Category { get; set; }
// public string CreatorId { get; set; }