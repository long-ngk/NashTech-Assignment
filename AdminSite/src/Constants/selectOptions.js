import {
  NormalCategoryType,
  LuxuryCategoryType,
  AllCategoryType,
  NormalCategoryTypeLabel,
  LuxyryCategoryTypeLabel,
  AllCategoryTypeLabel,
} from "../Constants/Category/CategoryConstants";

export const CategoryTypeOptions = [
  { id: 1, label: NormalCategoryTypeLabel, value: NormalCategoryType },
  { id: 2, label: LuxyryCategoryTypeLabel, value: LuxuryCategoryType },
];

export const FilterCategoryTypeOptions = [
  { id: 1, label: AllCategoryTypeLabel, value: AllCategoryType },
  { id: 2, label: NormalCategoryTypeLabel, value: NormalCategoryType },
  { id: 3, label: LuxyryCategoryTypeLabel, value: LuxuryCategoryType },
];
