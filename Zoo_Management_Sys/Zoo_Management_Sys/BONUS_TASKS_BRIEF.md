# Zoo Management System - Bonus Tasks Guide (Brief)

## 📋 Quick Navigation
1. [Aquatic Animals](#1-aquatic-animals) | 2. [Breeding Programs](#2-breeding-programs) | 3. [Visitor Management](#3-visitor-management) | 4. [Feeding Schedules](#4-feeding-schedules)
5. [Medical Records](#5-medical-records) | 6. [Exhibits](#6-exhibits) | 7. [Seasonal Behaviors](#7-seasonal-behaviors) | 8. [Educational Programs](#8-educational-programs)

---

## 1. Aquatic Animals

**Goal:** Add water-dwelling animals with swimming capabilities.

**New Classes:**
- Create `Aquatic_Classes/` folder with: Dolphin, Shark, Seal, Penguin

**Key Approach (choose one):**
- **Option A:** Abstract `Aquatic` class inheriting from `Animal`
- **Option B:** `ISwimmable` interface (better - Crocodile can also implement it!)

**Properties:** Swimming speed, Max depth, Can breathe underwater, Water type
**Methods:** `Swim()`, `Dive()`, `GetSwimmingSpeed()`
**Override:** `GetHabitat()` → "Ocean", "Coral Reef", etc.

---

## 2. Breeding Programs

**Goal:** Manage reproduction and conservation.

**BreedingProgram Class:**
- Program ID, Target species, Male/Female parents, Offspring list, Success rate
- Methods: `AttemptBreeding()`, `CheckBreedingEligibility()`, `RecordBirth()`

**Offspring Class:**
- Birth date, Parents, Birth weight, Health status → Eventually becomes full Animal

**Add to Animal:**
- Conservation status (enum), Gender, Can breed (bool), Is fertile (bool)

**Add to Zoo:**
- `AddBreedingProgram()`, `GetEndangeredAnimals()`, `MatchBreedingPairs()`

**Integration:** Check health (Medical), Check season (Seasonal Behaviors)

---

## 3. Visitor Management

**Goal:** Sell tickets, track visitors, calculate revenue.

**Visitor Class:**
- ID, Name, Age, Ticket type, Entry/Exit times, Visited exhibits
- Methods: `CheckIn()`, `CheckOut()`, `VisitExhibit()`

**Ticket Class:**
- ID, Type (enum: Adult/Child/Senior/Group/Annual), Price, Valid date
- Methods: `ValidateTicket()`, `CalculatePrice()`

**PricingStrategy Class:**
- Base prices (Dictionary), Seasonal multipliers, Discounts
- Methods: `GetTicketPrice()`, `ApplyDiscount()`

**Add to Zoo:**
- Visitors collection, Max capacity, `SellTicket()`, `GetDailyRevenue()`

---

## 4. Feeding Schedules

**Goal:** Manage feeding times and food inventory with time-based logic.

**FeedingSchedule Class:**
- Animal, Feeding times (List<TimeOnly>), Food type, Portion size, Assigned keeper
- Methods: `AddFeedingTime()`, `GetNextFeedingTime()`

**FeedingRecord Class:**
- Animal, Scheduled time, Actual time, Fed by, Amount given/eaten, Was on time
- Methods: `RecordFeeding()`, `CalculateDelay()`

**FoodInventory Class:**
- Food type, Quantity, Expiration date, Cost
- Methods: `UseFood()`, `RestockFood()`, `IsLowStock()`

**Add to Animal:** Diet type, Last fed time, `IsHungry()`
**Add to Zoo:** `GetOverdueFeedings()`, `GetFeedingCompliance()`
**Time Logic:** Use `DateTime.Now` and `TimeOnly` to compare times

---

## 5. Medical Records

**Goal:** Track health history, vet care, treatments.

**Veterinarian Class (like ZooKeeper):**
- Employee ID, Name, Specialization, License number
- Methods: `ExamineAnimal()`, `PrescribeTreatment()`, `AdministerVaccination()`

**MedicalRecord Class:**
- Animal, Vaccinations, Checkups, Treatments, Allergies, Weight history
- Methods: `AddVaccination()`, `IsVaccinationDue()`, `GetCompleteHistory()`

**Checkup Class:**
- Date, Vet, Animal, Weight, Temperature, Heart rate, Overall condition
- Methods: `RecordVitals()`, `ScheduleFollowUp()`

**Treatment Class:**
- Date, Diagnosis, Medication, Dosage, Duration, Cost, Success

**Vaccination Class:**
- Vaccine name, Date, Next due date, Lot number

**Add to Animal:** Medical record, Current health condition (enum), Primary vet
**Add to Zoo:** `GetSickAnimals()`, `GetAnimalsNeedingCheckup()`, `GetVeterinaryCosts()`

**Health Condition Enum:** Excellent, Good, Fair, Minor Illness, Severe, Critical

---

## 6. Exhibits

**Goal:** Physical spaces where animals live, with capacity limits.

**Exhibit Class:**
- ID, Name, Habitat type, Size, Max animal/visitor capacity
- Current animals, Current visitors, Temperature, Humidity, Status
- Assigned keepers, Special features
- Methods: `AddAnimal()`, `RemoveAnimal()`, `AdmitVisitor()`, `IsFull()`, `IsOvercrowded()`

**ExhibitRequirements Class:**
- Min size per animal, Temp/Humidity ranges, Water feature, Security level

**MaintenanceRecord Class:**
- Exhibit, Date, Type (Cleaning/Repair), Performed by, Cost, Issues found

**Add to Animal:** Current exhibit, Space requirements, Compatible species
**Add to Zoo:** Exhibits collection, `AssignAnimalToExhibit()`, `GetOvercrowdedExhibits()`
**Add to Visitor:** Current exhibit, Visited exhibits

**Status Enum:** Open, Closed, UnderMaintenance, EmergencyClosure

---

## 7. Seasonal Behaviors

**Goal:** Animals behave differently by season (hibernation, migration, breeding).

**Season Enum:** Spring, Summer, Fall, Winter
**Behavior Enum:** Hibernation, Migration, Breeding Season, Molting, None

**SeasonalPattern Class:**
- Species, Behavior type, Active season, Start/End dates
- Activity change %, Food consumption change %
- Methods: `IsCurrentlyActive()`, `CalculateAdjustedFoodCost()`

**HibernationPeriod Class:**
- Animal, Start/End dates, Pre/Current weight, Location, Health checks
- Methods: `BeginHibernation()`, `EndHibernation()`, `IsWeightLossNormal()`

**SeasonManager Class:**
- Current season (auto-detect from date), Zoo location
- Methods: `GetCurrentSeason()`, `GetAnimalsAffectedByCurrentSeason()`

**Add to Animal:** Seasonal patterns, Is hibernating, Current activity level
**Override:** `CalculateWeeklyCost()` - multiply by seasonal food multiplier
**Integration:** No feeding during hibernation, Breeding only in breeding season

---

## 8. Educational Programs

**Goal:** Tours, workshops, school programs for visitors.

**EducationalProgram Class (base):**
- Program ID, Name, Description, Target audience (enum), Duration
- Max/Min participants, Price, Animals featured, Schedule, Instructor
- Methods: `AddParticipant()`, `IsFull()`, `CalculateRevenue()`

**Tour Class (inherits EducationalProgram):**
- Tour route (List<Exhibit>), Tour guide, Walking distance, Tour type
- Methods: `AddTourStop()`, `StartTour()`, `EndTour()`

**Workshop Class (inherits EducationalProgram):**
- Workshop type, Location, Materials needed, Hands-on activities
- Methods: `SetupWorkshop()`, `ConductActivity()`

**SchoolProgram Class (inherits EducationalProgram):**
- Grade level, Curriculum alignment, Chaperone requirements, Discounted pricing

**Educator Class (like ZooKeeper):**
- Employee ID, Name, Specialization, Languages spoken, Programs taught
- Methods: `TeachProgram()`, `CreateCurriculum()`, `IsAvailable()`

**ProgramSchedule Class:**
- Program, Date, Start/End time, Instructor, Enrolled participants, Status
- Methods: `EnrollParticipant()`, `StartSession()`

**Add to Zoo:** Programs collection, Educators, `ScheduleProgram()`, `GetDailyProgramSchedule()`
**Add to Visitor:** Enrolled programs, Programs attended, `RegisterForProgram()`

**Audience Enum:** Preschool, Elementary, Teens, Adults, Families, All Ages

---

## 🔗 Integration Map

| Task Pair | How They Connect |
|-----------|------------------|
| **Aquatic + Exhibits** | Aquatic animals need aquarium exhibits with water quality monitoring |
| **Breeding + Medical** | Health clearance required before breeding, pregnancy tracking |
| **Breeding + Seasonal** | Animals only breed in specific seasons |
| **Visitors + Exhibits** | Track which exhibits visited, exhibit capacity limits |
| **Visitors + Programs** | Visitors purchase program tickets, track revenue |
| **Feeding + Seasonal** | Hibernating animals don't eat, adjust food by season |
| **Feeding + Medical** | Sick animals need special diets, appetite = health indicator |
| **Medical + Exhibits** | Sick animals quarantined, environmental conditions affect health |
| **Exhibits + Programs** | Programs happen at exhibits, behind-the-scenes tours |
| **Seasonal + Programs** | Programs focus on active animals, content changes by season |

---

## 📊 Implementation Order (Recommended)

**Phase 1 - Foundation:**
1. **Exhibits** - Animals need homes first
2. **Medical Records** - Essential health tracking

**Phase 2 - Operations:**
3. **Feeding Schedules** - Daily operations
4. **Aquatic Animals** - Expand variety
5. **Seasonal Behaviors** - Add realism

**Phase 3 - Advanced:**
6. **Breeding Programs** - Requires exhibits + health + seasons

**Phase 4 - Business:**
7. **Visitor Management** - Revenue tracking
8. **Educational Programs** - Requires visitors + exhibits

---

## 💡 Quick Implementation Tips

**File Structure:**
```
Classes/
├── Animals/Aquatic_Classes/, Mammal_Classes/, etc.
├── Medical/MedicalRecord.cs, Checkup.cs, Treatment.cs, Vaccination.cs
├── Breeding/BreedingProgram.cs, Offspring.cs
├── Feeding/FeedingSchedule.cs, FeedingRecord.cs, FoodInventory.cs
├── Exhibits/Exhibit.cs, MaintenanceRecord.cs
├── Seasonal/SeasonalPattern.cs, HibernationPeriod.cs, SeasonManager.cs
├── Education/EducationalProgram.cs, Tour.cs, Workshop.cs
├── Visitors/Visitor.cs, Ticket.cs, PricingStrategy.cs
└── Veterinarian.cs, Educator.cs, ZooKeeper.cs, Zoo.cs
```

**OOP Concepts Practiced:**
- **Inheritance:** EducationalProgram → Tour/Workshop, Animal → Aquatic
- **Interfaces:** ISwimmable, IHibernating, ISchedulable
- **Polymorphism:** Different behaviors for different animal types
- **Encapsulation:** Private collections, public methods
- **Collections:** Lists, Dictionaries, LINQ queries
- **Enums:** Seasons, TicketTypes, HealthConditions, etc.

**Testing Checklist:**
- ✅ Normal cases (everything works)
- ✅ Edge cases (capacity limits, empty collections)
- ✅ Error handling (null checks, validation)
- ✅ Integration (features work together)

**Start Small:**
1. Define core classes (properties + constructor)
2. Add validation
3. Add methods one by one
4. Test as you go
5. Add integration last

---

## 🎯 Final Checklist

Before moving to next task:
- [ ] All classes created?
- [ ] Properties with correct types?
- [ ] Methods implemented?
- [ ] Validation added?
- [ ] Integration with existing classes?
- [ ] Enums created where needed?
- [ ] Collections properly managed?
- [ ] Time logic working (for Feeding/Seasonal)?
- [ ] Tested edge cases?
- [ ] Updated Zoo class methods?

**Remember:** Think like a real zoo! How would actual zoos solve these problems? Watch documentaries, read about animal care. Better domain understanding = better code design.

Good luck! 🦁🐘🐧🦈🎓
