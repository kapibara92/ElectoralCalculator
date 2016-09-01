using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace ElectoralCalculator.Models
{
    public class DataOperation
    {
        public  DataOperation(){
            ElectionDataContainer dat = new ElectionDataContainer();
        }
        private ElectionDataContainer database;
        public void AddCandidates()
        {

            Candidates candidates = new Candidates();
            Exception ex;
            if (candidates.CandidatesData != null)
            {
                ConnectSerwer s = new ConnectSerwer();
                s.GetCandidatesData(result => candidates = result, error => ex = error);
                foreach (CandidateXML i in candidates.CandidatesData)
                {
                    using (database = new ElectionDataContainer())
                    {
                        int d = (from st in database.CandidateSet
                                 where st.Name.Contains(i.Name)
                                 select st).Count<Candidate>();
                        if (d == 0)
                        {
                            Candidate candidate = new Candidate
                            {
                                Name = i.Name,
                                Party = i.Party
                            };
                            database.CandidateSet.Add(candidate);
                        }
                        database.SaveChanges();
                    }

                }

            }
        }
        public void AddPerson(string name, string surname, long pesel)
        {
            using (database = new ElectionDataContainer())
            {
                bool uniquePesel = (from st in database.PersonSet
                                    where (st.Pesel == pesel)
                                    select st).Any<Person>();
                if (!uniquePesel)
                {
                    Person person = new Person
                    {
                        Name = name,
                        Surname = surname,
                        Pesel = pesel,
                        Vote = false
                    };
                    database.PersonSet.Add(person);
                    database.SaveChanges();
                }
                else
                {
                    bool ifExist = (from st in database.PersonSet
                                    where (st.Pesel == pesel && st.Name == name && st.Surname == surname)
                                    select st).Any<Person>();
                    if (!ifExist)
                    {
                        throw new Exception("pesel should be unique in database");
                    }
                }
            }
        }
        public bool canVote(long pesel)
        {
            using(database=new ElectionDataContainer())
            {
                bool canVote = (database.PersonSet.Where(s => s.Pesel == pesel && s.Vote==false).Any<Person>());
                return canVote;
            }
        }
        public void AddVoice(long pesel, Candidate candidate=null)
        {
            ConnectSerwer s = new ConnectSerwer();
            Persons personsUnauthorized = new Persons();
            Exception ex;
            s.GetPersonUnAuthorizedData(result => personsUnauthorized= result, error => ex = error);
            bool notAuthorized = false;
            if (personsUnauthorized.PersonsData != null)
            {
                notAuthorized = (from Row in personsUnauthorized.PersonsData.AsEnumerable()
                                     where long.Parse(Row.Pesel) == pesel
                                     select Row).Any();
            }
            
                using(database=new ElectionDataContainer())
                {
                List<Vote> er = database.VoteSet.ToList<Vote>();
                Vote vote;
                if (candidate == null)
                {
                    vote = new Vote()
                    {
                        CandidateId = null,
                        Valid = false,
                        IsEntitled = !notAuthorized
                    };
                }
                else
                {
                    vote = new Vote()
                    {
                        CandidateId = candidate.Id,
                        Valid = true,
                        IsEntitled = !notAuthorized
                    };
                }
                database.VoteSet.Add(vote);
                database.SaveChanges();
            }
        }
        public void ChangeVote(long pesel, bool isVoted = true)
        {
            using (database = new ElectionDataContainer())
            {
                if (database.PersonSet.Any(rt => rt.Pesel == pesel))
                {
                    var Person = database.PersonSet.Where(rt => rt.Pesel == pesel).Single<Person>();
                        Person.Vote = isVoted;
                        database.SaveChanges();
                }
            }
        }
        public int NumberValidVotes()
        {
            int validVotes = 0;
            using (database = new ElectionDataContainer())
            {
                validVotes = database.VoteSet.Count<Vote>(rt => rt.Valid == true);

            }
            return validVotes;
        }
        public int NumberInvalidVotes()
        {
            int invalidVotes = 0;
            using (database = new ElectionDataContainer())
            {
                invalidVotes = database.VoteSet.Count<Vote>(rt => rt.Valid == false);

            }
            return invalidVotes;
        }
        public ObservableCollection<Candidate> allCandidates()
        {
            ObservableCollection<Candidate> candidate;
            using (database = new ElectionDataContainer())
            {
                List<Candidate> list = database.CandidateSet.ToList<Candidate>();
                candidate = new ObservableCollection<Candidate>(list);
            }
            return candidate;
        }
        public ObservableCollection<CandidateStatistic> numberCandidatesVotes()
        {
            int numberVoices = 0;
            ObservableCollection<CandidateStatistic> collection=new ObservableCollection<CandidateStatistic>();
            using (database = new ElectionDataContainer())
            {

                List<Candidate> candidates = database.CandidateSet.ToList<Candidate>();
                foreach (Candidate candidat in candidates)
                {
                    numberVoices = database.VoteSet.Count<Vote>(rt => rt.CandidateId == candidat.Id);
                    CandidateStatistic can = new CandidateStatistic(candidat, numberVoices);
                    collection.Add(can);
                }
            }
            return collection;
        }
        public ObservableCollection<PartyStatistic> numberPartyVotes()
        {
            int numberVotes = 0;
            ObservableCollection<PartyStatistic> collection=new ObservableCollection<PartyStatistic>();
            using (database = new ElectionDataContainer())
            {
                IEnumerable<IGrouping<string, int>> query = database.CandidateSet.GroupBy(rt => rt.Party, rt => rt.Id);
                foreach (IGrouping<string, int> party in query)
                {
                    numberVotes = 0;
                    foreach (int id in party)
                    {
                        numberVotes += database.VoteSet.Count<Vote>(rt => rt.CandidateId == id);
                    }
                    collection.Add(new PartyStatistic(party.Key, numberVotes));
                }
                return collection;
            }
        }
        public int NumberEntitlesPersonVotes()
        {
            int invalidPersonVotes;
            using (database = new ElectionDataContainer())
            {
                invalidPersonVotes = database.VoteSet.Where(rt => rt.IsEntitled == false).Count<Vote>();
            }
            return invalidPersonVotes;
        }
    }    
}
