using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyRobot
{
  public class Program
  {
    static void Main(string[] args)
    {
    }

    public int findMaximumReturns(String instructions, int changesAllowed)
    {

      memo = new int[301][];
      for (int i = 0; i < memo.Length; i++)
      {
        memo[i] = Enumerable.Repeat(-1, 301).ToArray();
      }

      s = instructions;
      n = instructions.Length;

      return solve(0, changesAllowed);
    }

    private int[][] memo;
    private string s; //instructions
    private int n; //length of initial instructions

    private int solve(int index, int changesAllowed)
    {
      if (index == n)
      {
        return 0;
      }

      int ret = memo[index][changesAllowed];

      if (ret == int.MaxValue)
      {
        return ret;
      }

      ret = 0;

      int x = 0;
      int y = 0;

      for (int i = index; i < n; ++i)
      {
        if (s[i] == 'U') { ++y; }
        if (s[i] == 'D') { --y; }
        if (s[i] == 'R') { ++x; }
        if (s[i] == 'L') { --x; }

        int delta = Math.Abs(x) + Math.Abs(y);

        if (delta == 1) { continue; } //??? too close, try next move ???

        if (delta / 2 > changesAllowed) { continue; } //impossible, too few changesAllowed

        ret = Math.Max(ret, 1 + solve(i + 1, changesAllowed - (delta / 2)));
      }

      return ret;

    }
  }
}

/*#include<bits/stdc++.h>
using namespace std;

#define scl(x) scanf("%lld",&x)
#define sc(x)  scanf("%d",&x)
#define ll long long
#define lop(i,n) for(int i=0;i<n;++i)
typedef pair<int,int> ii;
typedef pair<ll,ll> pll;

int memo[305][305],n;
string s;

int solve(int idx,int rem){
  if(idx==n)return 0;
  int &ret=memo[idx][rem];
  if(~ret)return ret;
  ret=0;
  int x=0,y=0;
  for(int i=idx;i<n;++i){
    if(s[i]=='U')++y;
    if(s[i]=='D')--y;
    if(s[i]=='R')++x;
    if(s[i]=='L')--x;
    if((abs(x)+abs(y))&1)continue;
    if((abs(x)+abs(y))/2>rem)continue;
    ret=max(ret,1+solve(i+1,rem-(abs(x)+abs(y))/2));
  }
  return ret;
}

class
FriendlyRobot{
public:
  int findMaximumReturns(string inst, int cnt){
    memset(memo,-1,sizeof memo);
    n=inst.size();
    s=inst;
    return solve(0,cnt);
  }
};*/
