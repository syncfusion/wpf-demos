using System.Collections.Generic;

namespace ExpenseAnalysisDemo
{
    class Food
    {
        public string FoodName { get; set; }
        public int Calorie { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbohydrate { get; set; }

        public List<Food> GenerateMealSummary()
        {
            var mealSummary = new List<Food>
                {
                    new Food
                        {
                            FoodName = "CHEESEBURGER; REGULAR 1 SANDWITCH",
                            Calorie = 300,
                            Protein = 15,
                            Fat = 15,
                            Carbohydrate = 28
                        },
                    new Food
                        {
                            FoodName = "CHEESECAKE 1 PIECE",
                            Calorie = 280,
                            Protein = 5,
                            Fat = 18,
                            Carbohydrate = 26
                        },
                    new Food
                        {
                            FoodName = "PIZZA; CHEESE 1 SLICE",
                            Calorie = 290,
                            Protein = 15,
                            Fat = 9,
                            Carbohydrate = 39
                        },
                    new Food
                        {
                            FoodName = "PUDDING; CHOC; COOKED FROM MIX1/2 CUP",
                            Calorie = 150,
                            Protein = 4,
                            Fat = 4,
                            Carbohydrate = 25
                        },
                    new Food
                        {
                            FoodName = "SPAGHETTI;MEATBALLS;TOMSAC;CND1 CUP	",
                            Calorie = 260,
                            Protein = 12,
                            Fat = 10,
                            Carbohydrate = 29
                        },
                    new Food
                        {
                            FoodName = "TOMATO SOUP WITH MILK; CANNED 1 CUP",
                            Calorie = 160,
                            Protein = 6,
                            Fat = 6,
                            Carbohydrate = 22
                        },
                    new Food
                        {
                            FoodName = "CHICKEN NOODLE SOUP; CANNED 1 CUP",
                            Calorie = 75,
                            Protein = 4,
                            Fat = 2,
                            Carbohydrate = 9
                        },
                    new Food
                        {
                            FoodName = "YOGURT; W/ LOFAT MILK;FRUITFLV8 OZ",
                            Calorie = 230,
                            Protein = 10,
                            Fat = 2,
                            Carbohydrate = 43
                        },
                    new Food
                        {
                            FoodName = "POPCORN; SUGAR SYRUP COATED 1 CUP",
                            Calorie = 135,
                            Protein = 2,
                            Fat = 1,
                            Carbohydrate = 30
                        },
                    new Food
                        {
                            FoodName = "ROAST BEEF SANDWICH 1 SANDWH",
                            Calorie = 345,
                            Protein = 22,
                            Fat = 13,
                            Carbohydrate = 34
                        }
                };


            return mealSummary;
        }
    }


}
